using System;
using System.Collections.Generic;
using WayInfo;

namespace SortingTool
{
    public static class Sorting
    {
        public static bool sort(IList<IWayPart> list)
        {
            // признак безошибочной сортировки
            bool isSorted = true;
            for (int i = 0; i < list.Count - 1; i++)
            {
                // индексы первого и последнего элементов отсортированного на предыдущей итерации подсписка
                // на первой итерации он состоит из первого элемента
                int[] sortedSublistFstAndLstElemIndexes = i > 0 ? new int[] { 0, i } : new int[] { 0 };

                // индекс элемента, который будем переставлять (-1 - неопределенный)
                int selectedElemIndex = -1;
                // индекс первого или последнего элемента отсортированного подсписка,
                // относительного которого будем двигать выбранный элемент (-1 - неопределенный)
                int sortedSublistSelectedElemIndex = -1;
                // признак относительного положения элементов (0 - положение не определено)           
                int relativePosition = 0;    
                     
                // из оставшейся части списка подбираем элемент, который можно вставить либо
                // перед первым элементов отсортированного подсписка либо после последнего
                for (int j = i + 1; j < list.Count; j++)
                {
                    for (int k = 0; k < sortedSublistFstAndLstElemIndexes.Length; k++)
                    {                        
                        relativePosition = list[j].CompareTo(list[sortedSublistFstAndLstElemIndexes[k]]);
                        // ищем ближайший j-й элемент, для которого определено его положение относительно
                        // первого или последнего элемента отсортированного подсписка
                        if (relativePosition != 0)
                        {
                            sortedSublistSelectedElemIndex = sortedSublistFstAndLstElemIndexes[k];
                            selectedElemIndex = j;
                            break;
                        }
                    }

                    if (relativePosition != 0)                                            
                        break;                    
                }

                // если элемент не нашелся или нашелся, но место для его вставки 
                // правее первого или левее последнего элемента отсортированного подсписка длины большей единицы,
                // то исходный список имеет некорректные данные
                if (selectedElemIndex == -1 || 
                        (sortedSublistFstAndLstElemIndexes.Length == 2 &&
                            ((sortedSublistSelectedElemIndex == 0 && relativePosition > 0) || (sortedSublistSelectedElemIndex == i && relativePosition < 0))
                        )
                   )
                {
                    isSorted = false;
                    break;
                }

                // вычисляем новый индекс выбранного элемента относительно первого или последнего элемента отсортированного подсписка
                int selectedElemNewIndex = sortedSublistSelectedElemIndex + (relativePosition > 0 ? 1 : 0);

                // если новый индекс совпадает со старым, то переходим к следующей итерации
                if (selectedElemNewIndex == selectedElemIndex)
                    continue;

                // выполняем сдвиг элементов вправо (на старое место выбранного элемента)
                IWayPart tmp = list[selectedElemIndex];
                for (int j = selectedElemIndex - 1; j > selectedElemNewIndex - 1; j--)
                    list[j + 1] = list[j];
                // ставим выбранный элемент на новую позицию
                list[selectedElemNewIndex] = tmp;
            }

            return isSorted;
        }
    }
}
