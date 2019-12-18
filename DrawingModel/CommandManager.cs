using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrawingModel
{
    public class CommandManager
    {
        const string UNDO_WARNING = "Cannot Undo exception\n";
        const string REDO_WARNING = "Cannot Redo exception\n";
        Stack<ICommand> _undo = new Stack<ICommand>();
        Stack<ICommand> _redo = new Stack<ICommand>();

        // 執行所有動作
        public void Execute(ICommand command)
        {
            command.Execute();
            _undo.Push(command);// push command 進 undo stack
            _redo.Clear();// 清除redo stack
        }

        // 上一步
        public void Undo()
        {
            if (_undo.Count <= 0)
                throw new Exception(UNDO_WARNING);
            ICommand command = _undo.Pop();
            _redo.Push(command);
            command.CancelExecute();
        }

        // 取消上一步
        public void Redo()
        {
            if (_redo.Count <= 0)
                throw new Exception(REDO_WARNING);
            ICommand command = _redo.Pop();
            _undo.Push(command);
            command.Execute();
        }

        public bool IsRedoEnabled
        {
            get
            {
                return _redo.Count != 0;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return _undo.Count != 0;
            }
        }
    }
}
