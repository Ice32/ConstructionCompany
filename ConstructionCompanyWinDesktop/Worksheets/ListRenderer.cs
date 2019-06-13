using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ConstructionCompanyWinDesktop.Worksheets
{
    public class ListRenderer<T> where T:class
    {
        private readonly List<Control> _controls = new List<Control>();
        private readonly Control.ControlCollection _formControls;
        
        private readonly Func<T, int, Action, List<Control>> _renderer;
        private readonly List<T> _data;


        public ListRenderer(ref List<T> data, Control.ControlCollection controls, Func<T, int, Action, List<Control>> renderer)
        {
            _data = data;
            _renderer = renderer;
            _formControls = controls;
        }
        
        private void ClearTaskInputs()
        {
            _controls.ForEach(control =>
            {
                _formControls.Remove(control);
            });
        }

        public void RerenderTaskInputs()
        {
            ClearTaskInputs();  
            for (var i = 0; i < _data.Count; i++)
            {
                List<Control> controls = _renderer(_data[i], i, RerenderTaskInputs);
                foreach (Control t in controls)
                {
                    _controls.Add(t);
                    _formControls.Add(t);
                }
            }
        }
    }
}
