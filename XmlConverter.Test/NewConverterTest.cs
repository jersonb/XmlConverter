using Nfe.Lib;
using System;
using System.IO;
using Xunit;

namespace XmlConverter.Test
{
    public class NewConverterTest
    {
        [Theory]
        [InlineData(FilePathTest.CAFETEIRA_PATH, "6108")]
        [InlineData(FilePathTest.LIVRO_PATH, "6108")]
        public void NormalOperation(string path, string expected)
        {
            try
            {
                var xml = File.ReadAllText(path);
                var nfeDetail = NewConverter.GetDetail<Root>(xml);
                var cfop = nfeDetail.NfeProc.NFe.infNFe.det.prod.CFOP;
                Assert.Equal(expected, cfop);
            }
            catch (Exception ex)
            {
                Assert.Null(ex);
            }
        }

        [Theory]
        [InlineData(FilePathTest.CAFETEIRA_PATH, "6108")]
        [InlineData(FilePathTest.LIVRO_PATH, "6108")]
        public void GetNodeByTag(string path, string expected)
        {
            try
            {
                var xml = File.ReadAllText(path);

                var obj = NewConverter.GetDetail<nfeProcNFeInfNFe>(xml, "det");

                Assert.Equal(expected, obj.det.prod.CFOP);
            }
            catch (Exception ex)
            {
                Assert.Null(ex);
            }
        }
    }
}