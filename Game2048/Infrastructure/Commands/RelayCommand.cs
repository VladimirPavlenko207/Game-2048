using Game2048.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048.Infrastructure.Commands
{
    internal class RelayCommand : Command
    {
        private readonly Action<object> exequte;
        private readonly Func<object, bool> canExequte;

        public RelayCommand(Action<object> Exequte, Func<object, bool> CanExequte = null)
        {
            exequte = Exequte ?? throw new ArgumentNullException(nameof(Exequte));
            canExequte = CanExequte;
        }
        public override bool CanExecute(object parameter) => canExequte?.Invoke(parameter) ?? true;

        public override void Execute(object parameter) => exequte(parameter);
    }
}
