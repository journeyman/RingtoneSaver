using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AudioControls
{
    public interface IFile
    {
        double SizeInBytes { get; }
    }
}
