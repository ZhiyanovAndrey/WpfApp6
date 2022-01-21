using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp6
{
    class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperty; //создаем свойство зависимомти
        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }

        private string windDirection;
        public string WindDirection;

        private int windSpeed;
        public int WindSpeed;


        private int conditions;
        public int Conditions

        {
            get { return conditions; }
            set { 
                if(value == 0)  conditions = value;
                else Console.WriteLine("Введите значения: 0 – солнечно, 1 – облачно, 2 – дождь, 3 – снег");
            }
        }
public WeatherControl(string windDirection, int windSpeed, int conditions)
        {
            WindDirection = windDirection;
            WindSpeed = windSpeed;
            Conditions = conditions;

        }




        static WeatherControl() //статический конструктор для одноразовой передачи метаданных
        {
            TemperatureProperty = DependencyProperty.Register( //передаем метаданные методом Register()
               nameof(Temperature),
               typeof(int),
               typeof(WeatherControl),
               new FrameworkPropertyMetadata(            //класс сообщает или применяет метаданные для свойст зависимости
                   0,
                   FrameworkPropertyMetadataOptions.AffectsMeasure | //флаги
                   FrameworkPropertyMetadataOptions.AffectsRender,
                   null,                                       //действий при изменении нет
                   new CoerceValueCallback(CoerceTemperature)), //делегат, который может подкорректировать уже существующее значение свойства,
                                                                //если оно вдруг не попадает в диапазон допустимых значений
                   new ValidateValueCallback(ValidateTemperature));  //необязательный элемент делегат, который возвращает true, если значение проходит валидацию, и false - если не проходит


        }

        private static bool ValidateTemperature(object value)
        {
            int v = (int) value;
            if (v > -50 && v < 50)

                return true;
            else return false;
                    
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v > -50 && v < 50)
            
                return v;
            
            else return 0;
        }
    }
}
