using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaMeter.Shapes;
//данный интерфейс может быть расширен пользователем для добавления новых методов/свойств
public interface IShape
{
	double Area { get; }
}
