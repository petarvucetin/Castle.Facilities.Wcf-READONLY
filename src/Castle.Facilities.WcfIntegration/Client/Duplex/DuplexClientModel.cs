// Copyright 2004-2010 Castle Project - http://www.castleproject.org/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Castle.Facilities.WcfIntegration
{
	using System;
	using System.ServiceModel;

	public class DuplexClientModel : WcfClientModel<DuplexClientModel>
    {
        private InstanceContext callbackContext;

		public DuplexClientModel()
		{
		}

		public DuplexClientModel(IWcfEndpoint endpoint)
			: base(endpoint)
		{
		}

        public InstanceContext CallbackContext
        {
			get { return callbackContext; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                callbackContext = value; 
            }
        }

		public DuplexClientModel Callback(object callback)
		{
			CallbackContext = new InstanceContext(callback);
			return this;
		}

		public static DuplexClientModel On(IWcfEndpoint endpoint)
		{
			return new DuplexClientModel(endpoint);
		}
    }
}