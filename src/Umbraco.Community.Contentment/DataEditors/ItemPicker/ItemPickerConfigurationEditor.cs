﻿/* Copyright © 2019 Lee Kelleher, Umbrella Inc and other contributors.
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

using System.Collections.Generic;
using Umbraco.Core.IO;
using Umbraco.Core.PropertyEditors;

namespace Umbraco.Community.Contentment.DataEditors
{
    public class ItemPickerConfigurationEditor : ConfigurationEditor
    {
        public const string DefaultIcon = "defaultIcon";
        public const string DefaultValue = "defaultValue";
        public const string EnableDevMode = "enableDevMode";
        public const string EnableFilter = "enableFilter";
        public const string Items = "items";
        public const string OverlayView = "overlayView";
        public const string OverlayOrderBy = "overlayOrderBy";

        public ItemPickerConfigurationEditor()
            : base()
        {
            var listFields = new[]
            {
                 new ConfigurationField
                {
                    Key = "icon",
                    Name = "Icon",
                    View = IOHelper.ResolveUrl(IconPickerDataEditor.DataEditorViewPath)
                },
                new ConfigurationField
                {
                    Key = "name",
                    Name = "Name",
                    View = "textbox"
                },
                new ConfigurationField
                {
                    Key = "value",
                    Name = "Value",
                    View = "textbox"
                },
            };

            Fields.Add(
                Items,
                nameof(Items),
                "Configure the items for the item picker.",
                IOHelper.ResolveUrl(DataTableDataEditor.DataEditorViewPath),
                new Dictionary<string, object>()
                {
                    { DataTableConfigurationEditor.FieldItems, listFields },
                    { MaxItemsConfigurationField.MaxItems, 0 },
                    { DisableSortingConfigurationField.DisableSorting, Constants.Values.False },
                    { DataTableConfigurationEditor.RestrictWidth, Constants.Values.True },
                    { DataTableConfigurationEditor.UsePrevalueEditors, Constants.Values.False }
                });

            Fields.Add(
               EnableFilter,
               "Enable filter?",
               "Select to enable the search filter in the overlay selection panel.",
               "boolean");

            Fields.Add(new ItemPickerTypeConfigurationField());
            Fields.AddMaxItems();
            Fields.Add(new AllowDuplicatesConfigurationField());
            Fields.Add(new EnableMultipleConfigurationField());
            Fields.AddDisableSorting();
            Fields.AddHideLabel();
            Fields.Add(
                EnableDevMode,
                "Enable developer mode?",
                "Select to enable add the ability to edit the raw JSON data for the editor value.",
                "boolean");
        }

        public override IDictionary<string, object> ToValueEditor(object configuration)
        {
            var config = base.ToValueEditor(configuration);

            if (config.ContainsKey(OverlayView) == false)
            {
                config.Add(OverlayView, IOHelper.ResolveUrl(ItemPickerDataEditor.DataEditorOverlayViewPath));
            }

            return config;
        }
    }
}
