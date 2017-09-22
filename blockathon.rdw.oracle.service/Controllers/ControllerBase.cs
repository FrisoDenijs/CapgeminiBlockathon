using blockathon.smartcontract.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blockathon.rdw.oracle.service.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected readonly ISmartContract _smartContract;
        protected readonly ILogger _logger;
        // TODO: Replace with thread safe list
        protected static readonly IList<string> _inProgress = new List<string>();
        protected static readonly object _lockInProgress = new object();

        public ControllerBase(ILogger logger, ISmartContract smartContract)
        {
            _logger = logger;
            _smartContract = smartContract;
        }

        public bool IsBusy
        {
            get
            {
                lock(_lockInProgress)
                {
                    return _inProgress.Count > 0;
                }
            }
        }
        protected bool AddInProgress(string item)
        {
            if (!_inProgress.Contains(item))
            {
                lock (_lockInProgress)
                {
                    if (!_inProgress.Contains(item))
                    {
                        _inProgress.Add(item);
                        return true;
                    }
                }
            }
            return false;
        }

        protected void RemoveInProgress(string item)
        {
            if (_inProgress.Contains(item))
            {
                lock (_lockInProgress)
                {
                    if (_inProgress.Contains(item))
                    {
                        _inProgress.Remove(item);
                    }
                }
            }
        }
    }
}
