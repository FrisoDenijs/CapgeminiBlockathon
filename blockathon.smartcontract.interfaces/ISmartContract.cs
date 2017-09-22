using System;

namespace blockathon.smartcontract.interfaces
{
    public interface ISmartContract
    {
        /// <summary>
        /// Callouts the specified content.
        /// </summary>
        /// <param name="content">The content.</param>
        // TODO: Parameters aanpassen naar juiste contract
        void Callout(string content);
    }
}
