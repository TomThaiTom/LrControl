﻿using System;
using micdah.LrControlApi.Communication;
using micdah.LrControlApi.Modules.LrApplicationView;
using micdah.LrControlApi.Modules.LrControl;
using micdah.LrControlApi.Modules.LrDevelopController;
using micdah.LrControlApi.Modules.LrDialogs;
using micdah.LrControlApi.Modules.LrUndo;

namespace micdah.LrControlApi
{
    public class LrControlApi : IDisposable
    {
        private readonly PluginClient _pluginClient;
        private readonly LrControl _lrControl;
        private readonly LrDevelopController _lrDevelopController;
        private readonly LrApplicationView _lrApplicationView;
        private readonly LrDialogs _lrDialogs;
        private readonly LrUndo _lrUndo;

        public LrControlApi(int sendPort, int receivePort)
        {
            _pluginClient = new PluginClient(sendPort, receivePort);
            _pluginClient.ConnectionStatus += OnConnectionStatus;

            _lrControl           = new LrControl(new MessageProtocol<LrControl>(_pluginClient));
            _lrDevelopController = new LrDevelopController(new MessageProtocol<LrDevelopController>(_pluginClient));
            _lrApplicationView   = new LrApplicationView(new MessageProtocol<LrApplicationView>(_pluginClient));
            _lrDialogs           = new LrDialogs(new MessageProtocol<LrDialogs>(_pluginClient));
            _lrUndo              = new LrUndo(new MessageProtocol<LrUndo>(_pluginClient));

            _pluginClient.Open();
        }

        public bool IsConnected => _pluginClient.IsConnected;

        public ILrControl LrControl => _lrControl;
        public ILrDevelopController LrDevelopController => _lrDevelopController;
        public ILrApplicationView LrApplicationView => _lrApplicationView;
        public ILrDialogs LrDialogs => _lrDialogs;
        public ILrUndo LrUndo => _lrUndo;

        public void Dispose()
        {
            _pluginClient.Close();
        }

        public event Action<bool, string> ConnectionStatus;

        private void OnConnectionStatus(bool connected)
        {
            if (connected)
            {
                string apiVersion;
                if (LrControl.GetApiVersion(out apiVersion))
                {
                    ConnectionStatus?.Invoke(true, apiVersion);
                }
                else
                {
                    ConnectionStatus?.Invoke(false, null);
                }
            }
            else
            {
                ConnectionStatus?.Invoke(false, null);
            }
        }
    }
}