using System;
using System.Windows.Forms;
using mips_syntax.Entities;
using mips_syntax.utils;

namespace MIPSValidator
{
    public partial class MipsValidatorUI : Form
    {
        public MipsValidatorUI()
        {
            InitializeComponent();
        }

        private void TestInput(object sender, EventArgs e)
        {
            opListBox.Items.Clear();
            var i = 0;
            statusListBox.Items.Clear();
            var validator = new MipsValidator();
            var arguments = new Line(inputTextBox.Text);
            var operands = arguments.Instruction.ParseInstruction();
            var status = validator.IsSyntaxValid(operands);
            foreach (var operand in operands)
            {
                i++;
                if (i > 1)
                {
                    opListBox.Items.Add(string.Format("operand({0}) : {1}", i, operand.Replace(",",string.Empty)));
                }
                else
                {
                    opListBox.Items.Add(string.Format("Operator: {0}", operand.Replace(",",string.Empty)));
                }

            }
            //Check syntax
            if (status.Success.Equals(true))
            {
                var stat = validator.HasValidParams(operands);
                //Check parameters
                if (stat.Success.Equals(true))
                    statusListBox.Items.Add(string.Format("'{0}' is a valid mips instruction", arguments.Instruction));
                else
                    foreach (var reason in stat.Reasons)
                        statusListBox.Items.Add(reason);
            }
            else
            {
                foreach (var reason in status.Reasons)
                    statusListBox.Items.Add(reason);
            }
        }
    }
}
