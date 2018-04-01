using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Labs;

namespace CSLab4Server
{
    public class MathsImpl : MathsProccessor.MathsProccessorBase
    {
        private Dictionary<string, List<double>> clientHistory = new Dictionary<string, List<double>>();

        public override Task<Result> Jmp(Arguments request, ServerCallContext context)
        {
            List<double> list = clientHistory[request.ID];
            int index = Convert.ToInt32(request.Input - 1);

            list.Add(list[index]);
            return Task.FromResult(new Result() { Value = list.Last() });
        }

        public override Task<Result> Set(Arguments request, ServerCallContext context)
        {
            if (request.Input.IsIncorrectValue())
            {
                request.Input = 0;
            }

            clientHistory[request.ID] = new List<double>() { request.Input };
            return Task.FromResult(new Result() { Value = request.Input });
        }

        public override Task<Result> Add(Arguments request, ServerCallContext context)
        {
            List<double> list = clientHistory[request.ID];
            double result = list.Last() + request.Input;

            if (result.IsIncorrectValue())
            {
                result = list.Last();
            }

            list.Add(result);
            return Task.FromResult(new Result() { Value = list.Last() });
        }

        public override Task<Result> Div(Arguments request, ServerCallContext context)
        {
            if (request.Input == 0)
            {
                request.Input = 1;
            }

            List<double> list = clientHistory[request.ID];
            double result = list.Last() / request.Input;

            if (result.IsIncorrectValue())
            {
                result = list.Last();
            }

            list.Add(result);
            return Task.FromResult(new Result() { Value = list.Last() });
        }

        public override Task<Result> Mul(Arguments request, ServerCallContext context)
        {
            List<double> list = clientHistory[request.ID];
            double result = list.Last() * request.Input;

            if (result.IsIncorrectValue())
            {
                result = list.Last();
            }

            list.Add(result);
            return Task.FromResult(new Result() { Value = list.Last() });
        }

        public override Task<Result> Sub(Arguments request, ServerCallContext context)
        {
            List<double> list = clientHistory[request.ID];
            double result = list.Last() - request.Input;

            if (result.IsIncorrectValue())
            {
                result = list.Last();
            }

            list.Add(result);
            return Task.FromResult(new Result() { Value = list.Last() });
        }
    }
}
