using System;
using Xunit;
using Diretor;
namespace MeuAppTestes
{
    public class UnitTest1
    {
        [Fact]
        public void TestName()
        {
            //var validator = new DiretorInputPostDTO();
            Diretor d = new Diretor("Teste");
            Assert.Equal("Teste", diretor.nome);
        }
    }
}