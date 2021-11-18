using System.Threading;
using System.Windows.Forms;

namespace PartyPanelUI
{
    static class Program
    {
        static void Main(string[] args)
        {
            PartyPanelUI panelUi = new PartyPanelUI();

            new Thread(() => new PartyPanel(panelUi).Start()).Start();

            Application.Run(panelUi);
        }
    }
}
