﻿//
// Rau - An AT-Proto Bot Framework
// Copyright (C) 2024-2025 Seth Hendrick
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published
// by the Free Software Foundation, either version 3 of the License, or
// any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.
//

using Rau.Standard;

namespace Rau.Plugins.Canary
{
    public static class IRauApiExtensions
    {
        public static CanaryPlugin GetCanaryPlugin( this IRauApi api )
        {
            return api.GetPlugin<CanaryPlugin>( CanaryPlugin.PluginGuid );
        }

        public static void AddCanaryAccount( this IRauApi api, PdsAccount account, PdsPost post, string cronString )
        {
            api.GetCanaryPlugin().AccountManager.AddAccount( account, post, cronString );
        }

        public static void AddCanaryAccount( this IRauApi api, PdsAccount account, Func<PdsPost> post, string cronString )
        {
            api.GetCanaryPlugin().AccountManager.AddAccount( account, post, cronString );
        }
        
        public static void AddCanaryAccountWithDefaultMessage( this IRauApi api, PdsAccount account, string cronString )
        {
            api.AddCanaryAccount( account, () => CanaryPlugin.DefaultPost( api.DateTime, account ), cronString );
        }
    }
}
