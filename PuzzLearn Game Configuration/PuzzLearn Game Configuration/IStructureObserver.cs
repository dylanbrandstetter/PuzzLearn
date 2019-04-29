using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzLearn_Game_Configuration
{
    public interface IStructureObserver<T>
    {
        void Update(T newStruct, T oldStruct);
    }

    public interface IStructureSubject<T>
    {
        void Attach(IStructureObserver<T> o);
        void Detach(IStructureObserver<T> o);
        void Notify();
    }
}
