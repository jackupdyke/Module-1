﻿using System;
using System.Collections.Generic;
using TenmoClient.Models;
using TenmoClient.Services;

namespace TenmoClient
{
    public class TenmoApp
    {
        private readonly TenmoConsoleService console = new TenmoConsoleService();
        private readonly TenmoApiService tenmoApiService;

        public TenmoApp(string apiUrl)
        {
            tenmoApiService = new TenmoApiService(apiUrl);
        }

        public void Run()
        {
            bool keepGoing = true;
            while (keepGoing)
            {
                // The menu changes depending on whether the user is logged in or not
                if (tenmoApiService.IsLoggedIn)
                {
                    keepGoing = RunAuthenticated();
                }
                else // User is not yet logged in
                {
                    keepGoing = RunUnauthenticated();
                }
            }
        }

        private bool RunUnauthenticated()
        {
            console.PrintLoginMenu();
            int menuSelection = console.PromptForInteger("Please choose an option", 0, 2, 1);
            while (true)
            {
                if (menuSelection == 0)
                {
                    return false;   // Exit the main menu loop
                }

                if (menuSelection == 1)
                {
                    // Log in
                    Login();
                    return true;    // Keep the main menu loop going
                }

                if (menuSelection == 2)
                {
                    // Register a new user
                    Register();
                    return true;    // Keep the main menu loop going
                }
                console.PrintError("Invalid selection. Please choose an option.");
                console.Pause();
            }
        }

        private bool RunAuthenticated()
        {
            console.PrintMainMenu(tenmoApiService.Username);
            int menuSelection = console.PromptForInteger("Please choose an option", 0, 6);
            if (menuSelection == 0)
            {
                // Exit the loop
                return false;
            }

            if (menuSelection == 1)
            {
                // View your current balance
                ViewBalance();
            }

            if (menuSelection == 2)
            {
                // View your past transfers
                ViewTransfers();
            }

            if (menuSelection == 3)
            {
                // View your pending requests
                ViewPendingRequests();
            }

            if (menuSelection == 4)
            {
                // Send TE bucks
                SendTEBucks();
            }

            if (menuSelection == 5)
            {
                // Request TE bucks
                RequestTEBucks();
            }

            if (menuSelection == 6)
            {
                // Log out
                tenmoApiService.Logout();
                console.PrintSuccess("You are now logged out");
            }

            return true;    // Keep the main menu loop going
        }

        private void Login()
        {
            LoginUser loginUser = console.PromptForLogin();
            if (loginUser == null)
            {
                return;
            }

            try
            {
                ApiUser user = tenmoApiService.Login(loginUser);
                if (user == null)
                {
                    console.PrintError("Login failed.");
                }
                else
                {
                    console.PrintSuccess("You are now logged in");
                }
            }
            catch (Exception)
            {
                console.PrintError("Login failed.");
            }
            console.Pause();
        }

        private void Register()
        {
            LoginUser registerUser = console.PromptForLogin();
            if (registerUser == null)
            {
                return;
            }
            try
            {
                bool isRegistered = tenmoApiService.Register(registerUser);
                if (isRegistered)
                {
                    console.PrintSuccess("Registration was successful. Please log in.");
                }
                else
                {
                    console.PrintError("Registration was unsuccessful.");
                }
            }
            catch (Exception)
            {
                console.PrintError("Registration was unsuccessful.");
            }
            console.Pause();
        }

        private void ViewBalance()
        {
            try
            {
                decimal balance = tenmoApiService.GetBalance();
                if (balance != decimal.MinValue)
                {
                    console.PrintSuccess($"Your TE bucks balance is {balance:C}");
                }
            }
            catch (Exception ex)
            {
                console.PrintError(ex.Message);
            }
            console.Pause();
        }

        private void ViewTransfers()
        {
            try
            {
                List<Transfer> transfers = tenmoApiService.GetTransfers();
                if (transfers != null)
                {
                    console.PrintTransfers(transfers, tenmoApiService.UserId);
                    if (transfers.Count > 0)
                    {
                        Transfer transfer = console.PromptForTransferId("view", transfers);
                        if (transfer != null)
                        {
                            console.PrintTransfer(transfer);
                            console.Pause();
                        }
                    }
                    else
                    {
                        console.Pause();
                    }
                }
            }
            catch (Exception ex)
            {
                console.PrintError(ex.Message);
            }
        }

        private void ViewPendingRequests()
        {
            try
            {
                List<Transfer> transfers = tenmoApiService.GetPendingTransfers();
                if (transfers != null)
                {
                    console.PrintTransfers(transfers, tenmoApiService.UserId);
                    if (transfers.Count > 0)
                    {
                        string choice = console.PromptForApproveOrReject();
                        if (choice != null)
                        {
                            Transfer transfer = console.PromptForTransferId(choice, transfers);
                            if (transfer != null)
                            {
                                if (choice == "approve")
                                {
                                    transfer = tenmoApiService.ApproveTransfer(transfer.TransferId);
                                    if (transfer.TransferStatus == TransferStatus.Approved)
                                    {
                                        console.PrintSuccess("Approval was successful");
                                        console.PrintTransfer(transfer);
                                    }
                                    else
                                    {
                                        console.PrintError("Approval was not successful");
                                    }
                                }
                                else if (choice == "reject")
                                {
                                    transfer = tenmoApiService.RejectTransfer(transfer.TransferId);
                                    if (transfer.TransferStatus == TransferStatus.Rejected)
                                    {
                                        console.PrintSuccess("Rejection was successful");
                                        console.PrintTransfer(transfer);
                                    }
                                    else
                                    {
                                        console.PrintError("Rejection was not successful");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                console.PrintError(ex.Message);
            }
            console.Pause();
        }

        private void SendTEBucks()
        {
            try
            {
                List<User> users = tenmoApiService.GetUsers();
                NewTransfer newTransfer = console.PromptForTransfer(TransferType.Send, users, tenmoApiService.UserId);
                if (newTransfer == null)
                {
                    // cancel
                    return;
                }
                Transfer addedTransfer = tenmoApiService.AddTransfer(newTransfer);
                if (addedTransfer != null)
                {
                    console.PrintTransfer(addedTransfer);
                }
            }
            catch (Exception ex)
            {
                console.PrintError(ex.Message);
            }
            console.Pause();
        }

        private void RequestTEBucks()
        {
            try
            {
                List<User> users = tenmoApiService.GetUsers();
                NewTransfer newTransfer = console.PromptForTransfer(TransferType.Request, users, tenmoApiService.UserId);
                if (newTransfer == null)
                {
                    // cancel
                    return;
                }
                Transfer addedTransfer = tenmoApiService.AddTransfer(newTransfer);
                if (addedTransfer != null)
                {
                    console.PrintTransfer(addedTransfer);
                }
            }
            catch (Exception ex)
            {
                console.PrintError(ex.Message);
            }
            console.Pause();
        }
    }
}
