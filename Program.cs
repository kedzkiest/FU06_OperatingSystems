using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    class Program
    {
        static bool LRU_ShouldReplace(Memory[] mem, int val)
        {
            for(int i = 0; i < mem.Length; i++)
            {
                if (mem[i].value == val)
                {
                    mem[i].passedTime = 0;
                    return false;
                }
            }
            return true;
        }

        static bool FIFO_ShouldReplace(Memory[] mem, int val)
        {
            for (int i = 0; i < mem.Length; i++)
            {
                if (mem[i].value == val)
                {
                    return false;
                }
            }
            return true;
        }

        static int FindLongestNotUsedIndex(Memory[] mem)
        {
            int max = mem.Max(value => value.passedTime);
            for(int i = 0; i < mem.Length; i++)
            {
                if(mem[i].passedTime == max)
                {
                    return i;
                }
            }
            return -1;
        }

        static void Count(Memory[] mem)
        {
            for(int i = 0; i < mem.Length; i++)
            {
                mem[i].passedTime++;
            }
        }

        static void LRUReplacement(List<int> _referenceStrings, int frameNum)
        {
            List<int> referenceStrings = new List<int>(_referenceStrings);
            int pageFaults = 0;
            Memory[] memory = new Memory[frameNum];

            for (int i = 0; i < memory.Length; i++)
            {
                memory[i] = new Memory(0, 0);
            }

            while (true)
            {
                if (referenceStrings.Count == 0) break;

                Count(memory);
                for (int i = 0; i < memory.Length; i++)
                {
                    if (memory[i].value == 0)
                    {
                        memory[i].value = referenceStrings[i];
                        memory[i].passedTime = 0;
                        pageFaults++;
                    }
                    else
                    {
                        if (LRU_ShouldReplace(memory, referenceStrings[i]))
                        {
                            int index = FindLongestNotUsedIndex(memory);
                            memory[index].value = referenceStrings[i];
                            memory[index].passedTime = 0;
                            pageFaults++;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                referenceStrings.RemoveAt(0);

            }
            Console.WriteLine(pageFaults);
        }

        static void FIFOReplacement(List<int> _referenceStrings, int frameNum)
        {
            List<int> referenceStrings = new List<int>(_referenceStrings);
            int pageFaults = 0;
            Memory[] memory = new Memory[frameNum];

            for (int i = 0; i < memory.Length; i++)
            {
                memory[i] = new Memory(0, 0);
            }

            while (true)
            {
                if (referenceStrings.Count == 0) break;

                Count(memory);
                for (int i = 0; i < memory.Length; i++)
                {
                    if (memory[i].value == 0)
                    {
                        memory[i].value = referenceStrings[i];
                        memory[i].passedTime = 0;
                        pageFaults++;
                    }
                    else
                    {
                        if (FIFO_ShouldReplace(memory, referenceStrings[i]))
                        {
                            int index = FindLongestNotUsedIndex(memory);
                            memory[index].value = referenceStrings[i];
                            memory[index].passedTime = 0;
                            pageFaults++;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                referenceStrings.RemoveAt(0);

            }
            Console.WriteLine(pageFaults);
        }
       
        static void Main(string[] args)
        {
            List<int> referenceStrings = new List<int>(){
            1, 2, 3, 4, 2, 1, 5, 6, 2, 1, 2, 3,
            7, 6, 3, 2, 1, 2, 3, 6};

            LRUReplacement(referenceStrings, 3);
            LRUReplacement(referenceStrings, 4);
            FIFOReplacement(referenceStrings, 3);
            FIFOReplacement(referenceStrings, 4);
        }

    }

    class Memory
    {
        public int value = 0;
        public int passedTime = 0;

        public Memory(int _value, int _passedTime)
        {
            this.value = _value;
            this.passedTime = _passedTime;
        }
    }
}