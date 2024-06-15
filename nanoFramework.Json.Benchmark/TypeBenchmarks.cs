﻿using System;
using System.Collections;
using System.Text;
using nanoFramework.Benchmark;
using nanoFramework.Benchmark.Attributes;
using nanoFramework.Json.Benchmark.Base;

namespace nanoFramework.Json.Benchmark
{
    [IterationCount(100)]
    public class TypeBenchmarks: BaseIterationBenchmark
    {
        protected override int IterationCount => 200;
        
        private readonly ArrayList _list = new();
        private const string ArrayListFullName = "System.Collections.ArrayList";
        private static readonly Type ArrayListType = typeof(ArrayList);

        [Benchmark]
        public void Benchmark_FullName_Comparison()
        {
            RunInIteration(() =>
            {
                if (!ArrayListFullName.Equals(_list.GetType().FullName))
                {
                    throw new Exception();
                }
            });
        }

        [Benchmark]
        public void Benchmark_Type_Comparison()
        {
            RunInIteration(() =>
            {
                if (_list.GetType() != typeof(ArrayList))
                {
                    throw new Exception();
                }
            });
        }

        [Benchmark]
        public void Benchmark_Type_Comparison_Static()
        {
            RunInIteration(() =>
            {
                if (_list.GetType() != ArrayListType)
                {
                    throw new Exception();
                }
            });
        }
    }
}
