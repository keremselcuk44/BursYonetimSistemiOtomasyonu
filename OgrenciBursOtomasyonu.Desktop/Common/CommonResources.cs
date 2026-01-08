namespace OgrenciBursOtomasyonu.Desktop.Common
{
    /// <summary>
    /// Common resource strings used throughout the application.
    /// </summary>
    internal static class CommonResources
    {
        /// <summary>
        /// Confirmation dialog caption.
        /// </summary>
        internal static string Confirmation_Caption => "Confirmation";

        /// <summary>
        /// Delete confirmation message format.
        /// </summary>
        internal static string Confirmation_Delete => "Do you want to delete this {0}?";

        /// <summary>
        /// Reset confirmation message.
        /// </summary>
        internal static string Confirmation_Reset => "Click OK to reload the entity and lose unsaved changes. Click Cancel to continue editing data.";

        /// <summary>
        /// Reset layout confirmation message.
        /// </summary>
        internal static string Confirmation_ResetLayout => "Are you sure you want to reset layout? Reopen this view for the new layout to take effect.";

        /// <summary>
        /// Save confirmation message.
        /// </summary>
        internal static string Confirmation_Save => "Do you want to save changes?";

        /// <summary>
        /// Save parent confirmation message format.
        /// </summary>
        internal static string Confirmation_SaveParent => "You need to save the parent {0} entity before adding a new record. Do you want to save it now?";

        /// <summary>
        /// Entity changed indicator.
        /// </summary>
        internal static string Entity_Changed => " *";

        /// <summary>
        /// New entity indicator.
        /// </summary>
        internal static string Entity_New => " (New)";

        /// <summary>
        /// Data service request error caption.
        /// </summary>
        internal static string Exception_DataServiceRequestErrorCaption => "DataService Request Error";

        /// <summary>
        /// Update error caption.
        /// </summary>
        internal static string Exception_UpdateErrorCaption => "Update Error";

        /// <summary>
        /// Validation error caption.
        /// </summary>
        internal static string Exception_ValidationErrorCaption => "Validation Error";

        /// <summary>
        /// Warning dialog caption.
        /// </summary>
        internal static string Warning_Caption => "Warning";

        /// <summary>
        /// Warning message for invalid data.
        /// </summary>
        internal static string Warning_SomeFieldsContainInvalidData => "Some fields contain invalid data. Click OK to close the page and lose unsaved changes. Press Cancel to continue editing data.";
    }
}

