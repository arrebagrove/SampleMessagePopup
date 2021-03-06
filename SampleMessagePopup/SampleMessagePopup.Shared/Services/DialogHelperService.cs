﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using SampleMessagePopup.Interfaces;

namespace SampleMessagePopup.Services
{
    /// <summary>
    /// Helper class for showing message dialogs
    /// </summary>
    public class DialogHelperService : IDialogHelperService
    {
        /// <summary>
        /// Shows a dialog with given message and ok/cancel buttons. 
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="title">Title</param>
        /// <param name="okText">OK text (optional)</param>
        /// <param name="cancelText">Cancel text (optional)</param>
        /// <returns>True if ok pressed, false otherwise</returns>
        public async Task<bool> ShowMessageDialog(string message, string title, string okText, string cancelText)
        {
            bool result = false;
            var dialog = new MessageDialog(message, title);

            if (!string.IsNullOrWhiteSpace(okText))
            {
                dialog.Commands.Add(new UICommand(okText, cmd => result = true));
            }

            if (!string.IsNullOrWhiteSpace(cancelText))
            {
                dialog.Commands.Add(new UICommand(cancelText, cmd => result = false));
            }

            await dialog.ShowAsync();
            return result;
        }
    }
}
