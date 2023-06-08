using TaquinPuzzle.Model;

namespace TaquinPuzzle;

public partial class Form1 : Form
{
    public Grid _grid { get; set; }

    public Form1()
    {
        InitializeComponent();
    }

    private void numericGridSize_ValueChanged(object sender, EventArgs e)
    {
        numericNbAgents.Maximum = numericGridSize.Value;
    }

    private void btnRun_Click(object sender, EventArgs e)
    {
        _grid = new Grid((int)numericGridSize.Value, (int)numericNbAgents.Value);
    }
}