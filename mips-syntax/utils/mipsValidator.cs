using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using mips_syntax.Entities;

namespace mips_syntax.utils
{
    public class MipsValidator : IMipsValidator
    {
        
        #region Implementation of IMipsValidator

        public Response IsSyntaxValid(List<string> args)
        {
            var response = new Response {Success = true};
            Operator op;

            try
            {
                op = (Operator)Enum.Parse(typeof(Operator), args[0]);
            }
            catch (Exception)
            {

                op = Operator.invalid;
            }

            switch (op)
            {
                case Operator.addi:
                case Operator.add:
                case Operator.beq:
                    if (args.Count != 4)
                    {
                        response.Reasons.Add(string.Format("4 operands required for {0}, {1} parameters provided.",
                                                           op, args.Count));
                        response.Success = false;
                    }
                    break;
                case Operator.j:
                    if (args.Count != 2)
                    {
                        response.Reasons.Add(string.Format("1 operands required for {1}, {0} parameters provided.",
                                                           args.Count, op));
                        response.Success = false;
                    }
                    break;
                default:
                    response.Reasons.Add(string.Format("{0}: is an unknown mips operation", args[0]));
                    response.Success = false;
                    break;
            }
            return response;
        }

        public Response HasValidParams(List<string> parameters)
        {
            string target, source1, source2;
            Operator operation;
            var response = new Response {Success = true};
            var opString = parameters[0];
            Enum.TryParse(opString.Replace("$", string.Empty), true, out operation);
            switch (operation)
            {
                case Operator.add:
                    {
                        target = parameters[1];
                        source1 = parameters[2];
                        source2 = parameters[3];
                        if (!target.CanWriteTo())
                        {

                            response.Reasons.Add(
                                string.Format("{0}: error temporary or store error register expected", target));
                            response.Success = false;
                        }
                        if (!source1.CanReadFrom() )
                        {
                            response.Reasons.Add(
                                string.Format("{0}: error temporary or store error register expected", source1));
                            response.Success = false;
                        }
                        if (!source2.CanReadFrom(true) )
                        {
                            response.Reasons.Add(string.Format("{0}: error temporary or store error register expected", source2));
                            response.Success = false;
                        }
                    }
                    break;
                case Operator.addi:
                    {
                        target = parameters[1];
                        source1 = parameters[2];
                        source2 = parameters[3];
                        if (!target.CanWriteTo())
                        {
                            response.Reasons.Add(string.Format("{0}: error temporary or store error register expected", target));
                            response.Success = false;
                        }
                        if (!source1.CanReadFrom())
                        {
                            response.Reasons.Add(string.Format("{0}: error temporary or store error register expected", source1));
                            response.Success = false;
                        }
                        if (!source2.IsMIPSConstant(true))
                        {
                            response.Reasons.Add(string.Format("{0}: error constant expected.", source2));
                            response.Success = false;
                        }
                    }
                    break;
                case Operator.beq:
                    {
                        source1 = parameters[1];
                        source2 = parameters[2];
                        target = parameters[3];
                        if (!source1.CanReadFrom())
                        {
                            response.Reasons.Add(string.Format("{0}: error temporary or store error register expected", source1));
                            response.Success = false;
                        }
                        if (!source2.CanReadFrom())
                        {
                            response.Reasons.Add(string.Format("{0}: error temporary or store error register expected", source2));
                            response.Success = false;
                        }
                        if (!target.IsLabel() && !target.IsMIPSConstant())
                        {
                            response.Reasons.Add(string.Format("{0}: error label or constant expected", target));
                            response.Success = false;
                        }
                    }
                    break;
            }

            return response;
        }


        #endregion
    }
}