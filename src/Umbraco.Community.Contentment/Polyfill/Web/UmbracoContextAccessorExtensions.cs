﻿/* This Source Code has been copied from Lee Kelleher's Umbraco Polyfill library.
 * https://github.com/leekelleher/umbraco-polyfill/blob/main/src/Web/UmbracoContextAccessorExtensions.cs
 * Modified under the permissions of the MIT License.
 * Modifications are licensed under the Mozilla Public License.
 * Copyright © 2022 Lee Kelleher.
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/. */

#if NET472
namespace Umbraco.Web
{
    internal static class UmbracoContextAccessorExtensions
    {
        public static UmbracoContext GetRequiredUmbracoContext(this IUmbracoContextAccessor accessor)
        {
            return accessor.UmbracoContext;
        }

        public static bool TryGetUmbracoContext(this IUmbracoContextAccessor accessor, out UmbracoContext umbracoContext)
        {
            umbracoContext = accessor.UmbracoContext;

            return umbracoContext != null;
        }
    }
}
#endif
