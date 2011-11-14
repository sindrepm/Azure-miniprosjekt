﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;
using AzureBlog.Model.Repository.Concrete;
using AzureBlog.Model;
using System.ServiceModel;

namespace AzureBlog.TagCloudService
{
    public class WorkerRole : RoleEntryPoint
    {
        private ServiceHost _serviceHost;

        public override void Run()
        {
            Trace.WriteLine("AzureBlog.TagCloudService entry point called", "Information");

            // Keep on going...
            while (true)
            {
                Thread.Sleep(300000);
                Trace.TraceInformation("Working...", "Information");
            }
        }

        /// <summary>
        /// Starts the internal and external endpoint for the WCF service hosting the compute instance.
        /// </summary>
        /// <param name="retries">Specifies number of retries in case of failure. </param>
        private void StartTagCloudServiceHost(int retries)
        {
            // recycle the role if host cannot be started 
            // after the specified number of retries
            if (retries == 0)
            {
                RoleEnvironment.RequestRecycle();
                return;
            }
            Trace.TraceInformation("Starting TagCloud service host...");
            _serviceHost = new ServiceHost(typeof(TagCloudService));
            // Recover the service in case of failure. 
            // Log the fault and attempt to restart the service host. 
            _serviceHost.Faulted += (sender, e) =>
            {
                Trace.TraceError("Host fault occured. Aborting and restarting the host. Retry count: {0}", retries);
                this._serviceHost.Abort();
                this.StartTagCloudServiceHost(--retries);
            };
            // use NetTcpBinding with no security
            NetTcpBinding tcpBinding = new NetTcpBinding(SecurityMode.None);
            // define an external endpoint for client traffic
            RoleInstanceEndpoint externalEndPointTcp = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["TagCloudServiceTcp"];
            RoleInstanceEndpoint externalEndPointHttp = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["TagCloudServiceHttp"];
            _serviceHost.AddServiceEndpoint(
               typeof(ITagCloudService),
               tcpBinding,
               String.Format("net.tcp://{0}/TagCloudService", externalEndPointTcp.IPEndpoint)
            );

            BasicHttpBinding httpBinding = new BasicHttpBinding(BasicHttpSecurityMode.None);
            _serviceHost.AddServiceEndpoint(
                typeof(ITagCloudService),
                httpBinding,
                string.Format("http://{0}", externalEndPointHttp.IPEndpoint));

            try
            {
                _serviceHost.Open();
                Trace.TraceInformation("TagCloud service host started successfully.");
            }
            catch (TimeoutException timeoutException)
            {
                Trace.TraceError("The service operation timed out. {0}", timeoutException.Message);
            }
            catch (CommunicationException communicationException)
            {
                Trace.TraceError("Could not start service host. {0}", communicationException.Message);
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections 
            ServicePointManager.DefaultConnectionLimit = 12;

            StartTagCloudServiceHost(3);

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            return base.OnStart();
        }
    }
}
