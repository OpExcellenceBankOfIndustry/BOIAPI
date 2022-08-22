using AutoMapper;
using BOI.BOIApplications.Application.Contracts.Legacy.Persistence;
using BOI.BOIApplications.Application.Model.ConfigurationModels;
using BOI.BOIApplications.Application.Model.WorkerService;
using BOI.BOIApplications.Legacy.Domain.Entites;
using DirectoryFileReader;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace BOI.BOIApplications.Application.Features.WorkerService.CreateEmployee
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Unit>
    {

        private readonly ILogger<CreateEmployeeCommandHandler> _logger;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ServiceConfigurationSettings _serviceConfigurtionSettings;
        private readonly ReadFileFromDirectory _readFileFromDirectory;

        public CreateEmployeeCommandHandler(ILogger<CreateEmployeeCommandHandler> logger, IEmployeeRepository employeeRepository,
            IMapper mapper, IOptions<ServiceConfigurationSettings> serviceConfigurtionSettings)
        {
            _readFileFromDirectory = new ReadFileFromDirectory();
            _logger = logger;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _serviceConfigurtionSettings = serviceConfigurtionSettings.Value;
        }

        public async Task<Unit> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var fileData = await _readFileFromDirectory.ProcessNewFilesAsync(_serviceConfigurtionSettings.EmployeeFolderPath);
                _logger.LogInformation($"file read info {JsonConvert.SerializeObject(fileData)}");
                if (fileData.AllFileSuccessFullyRead.AllFileWasRead && fileData.ProcessedFileCount > 0)
                {
                    foreach (var information in fileData.ProcessFileInformation)
                    {
                        _logger.LogInformation($"About to read file {information.ProcessedFileName} at {DateTime.Now}");
                        var employeeDataToInsert = JsonConvert.DeserializeObject<List<BonitaProfileCreationTemplate>>(information.ProcessedFileData);
                        employeeDataToInsert = employeeDataToInsert.Where(x => !string.IsNullOrEmpty(x.AccountNumber) && !string.IsNullOrEmpty(x.Department) &&
                                                    !string.IsNullOrEmpty(x.Grade) && !string.IsNullOrEmpty(x.Location) && !string.IsNullOrEmpty(x.Division) &&
                                                    !string.IsNullOrEmpty(x.StaffId) && x.SN != null && !string.IsNullOrEmpty(x.FirstName) && !string.IsNullOrEmpty(x.LastName) &&
                                                    !string.IsNullOrEmpty(x.Role) && !string.IsNullOrEmpty(x.Unit) && !string.IsNullOrEmpty(x.Username)).ToList();
                        foreach (var employeeData in employeeDataToInsert)
                        {
                            if (!await _employeeRepository.DoesEmployeeExist(employeeData.StaffId))
                            {
                                var data = _mapper.Map<Boiemployee>(employeeData);
                                await _employeeRepository.AddAsync(data);
                            }
                            _logger.LogInformation($"employee with staff id - {employeeData.StaffId} already exist for file {information.ProcessedFileName}");
                        }
                    }

                }
                else
                {
                    if (fileData == null)
                    {
                        foreach (var information in fileData.UnProcessFileInformation)
                        {
                            _logger.LogInformation($"Could not read {information.UnProcessedFileName} because  at {DateTime.Now}");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An exception occurred at CreateEmployeeCommandHandler {nameof(Handle)}");
            }

            return Unit.Value;
        }
    }
}
