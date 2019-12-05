using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game.Penguins;
using Game.Penguins.Core.Socrate;
using System.Linq;
using System.Collections.Generic;

namespace Game.Penguins.AI.UnitTests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]    
		public void TestValeurPoisson()
		{
			Board plateau = new Board();

            List<int> tabTest = plateau.GenerationPoisson();
			int resul = tabTest.Count(c => c == 1);
			int resul2 = tabTest.Count(c => c == 2);
			int resul3 = tabTest.Count(c => c == 3);
            Assert.IsTrue(resul == 34 && resul2 == 20 && resul3 == 10);
		}
    }
}
