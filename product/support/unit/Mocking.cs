using System;
using System.Linq.Expressions;
using Moq;

namespace unit
{
    public static class Mocking
    {
        public static void received<T>(this Mock<T> mock, Expression<Action<T>> action) where T : class
        { 
            mock.Verify(action);
        }
        
    }
}