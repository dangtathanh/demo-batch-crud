using Microsoft.Extensions.Logging;
using NetCore.BatchCRUD.Infrastructures.Constans;
using NetCore.BatchCRUD.Infrastructures.Helpers;
using NetCore.BatchCRUD.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetCore.BatchCRUD.Menus
{
    public class MainMenu : BaseMenu<MainMenu>
    {
        private readonly IBookCreationService _bookCreationService;
        private readonly IBookUpdateService _bookUpdateService;
        private readonly string _categoryName = "MENU";

        public MainMenu(IBookCreationService bookCreationService,
                            IBookUpdateService bookUpdateService,
                            ILoggerFactory loggerFactory) : base(loggerFactory)
        {
            _bookCreationService = bookCreationService;
            _bookUpdateService = bookUpdateService;
        }

        public async Task ShowOptionsAndExecuteAsync()
        {
            // List all available options
            ListOptions();

        Select:
            Console.WriteLine();
            Console.WriteLine("Enter: ");
            var option = ValidationHelper.GetInteger(InputHelper.ReadLineWithCancel(out bool exit), 0);
            if (exit)
            {
                _logger.LogInformation($"You exited menu '{_categoryName}'");
                return;
            }

            // Read selected option
            if (option < 1 || option > Options.Count)
            {
                Console.WriteLine();
                Console.WriteLine("You entered an invalid option, please re-enter a valid one.");
                goto Select;
            }

            // Execute action
            _logger.LogInformation($"You selected option '{option} - {Options[option]}' from {_categoryName}");
            await PerformActionAsync(option);
        }

        private async Task PerformActionAsync(int actionIndex)
        {
            bool exit = false;
            switch (actionIndex)
            {
                case 1:
                EnterBatchSize:
                    Console.WriteLine();
                    Console.WriteLine("Enter number of data you want to create:");
                    var value = ValidationHelper.GetInteger(InputHelper.ReadLineWithCancel(out exit), 0);
                    if (exit)
                    {
                        _logger.LogInformation($"You exited menu '{_categoryName}'");
                        return;
                    }

                    if (value == 0)
                    {
                        _logger.LogInformation("You have entered an invalid value");
                        goto EnterBatchSize;
                    }

                    await _bookCreationService.CreateManyAsync(value);

                    await ShowOptionsAndExecuteAsync();
                    break;
                case 2:
                EnterDate:
                    Console.WriteLine();
                    Console.WriteLine("Enter the date to update:");
                    var beforeDate = ValidationHelper.GetDateTime(InputHelper.ReadLineWithCancel(out exit), "yyyy-MM-dd", (DateTime?)null);
                    if (exit)
                    {
                        _logger.LogInformation($"You exited menu '{_categoryName}'");
                        return;
                    }
                    if (beforeDate == null)
                    {
                        _logger.LogInformation("You have entered an invalid value");
                        goto EnterDate;
                    }


                EnterFromStatus:
                    Console.WriteLine();
                    Console.WriteLine("Enter the current status:");
                    var fromStatusNumber = ValidationHelper.GetInteger(InputHelper.ReadLineWithCancel(out exit), 0);
                    if (exit)
                    {
                        _logger.LogInformation($"You exited menu '{_categoryName}'");
                        return;
                    }
                    if (!Enum.TryParse(fromStatusNumber.ToString(), out Status fromStatus))
                    {
                        _logger.LogInformation("You have entered an invalid value");
                        goto EnterFromStatus;
                    }


                EnterToStatus:
                    Console.WriteLine();
                    Console.WriteLine("Enter the new status:");
                    var toStatusNumber = ValidationHelper.GetInteger(InputHelper.ReadLineWithCancel(out exit), 0);
                    if (exit)
                    {
                        _logger.LogInformation($"You exited menu '{_categoryName}'");
                        return;
                    }
                    if (!Enum.TryParse(toStatusNumber.ToString(), out Status toStatus))
                    {
                        _logger.LogInformation("You have entered an invalid value");
                        goto EnterToStatus;
                    }

                    await _bookUpdateService.UpdateManyAsync((DateTime)beforeDate, fromStatus, toStatus);

                    await ShowOptionsAndExecuteAsync();
                    break;
            }
        }

        private readonly Dictionary<int, string> Options = new Dictionary<int, string>() {
            { 1, "Create bulk data" },
            { 2, "Update bulk data" }
        };

        private void ListOptions()
        {
            Console.WriteLine();
            Console.WriteLine("------");
            Console.WriteLine($"[{_categoryName.ToUpper()}] Please enter one option below or 'B' to go back:");
            foreach (var item in Options)
            {
                Console.WriteLine($"{item.Key}_ {item.Value}");
            }
            Console.WriteLine();
        }
    }
}
