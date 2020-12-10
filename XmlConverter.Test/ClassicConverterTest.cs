using Xunit;

namespace XmlConverter.Test
{
    public class ClassicConverterTest
    {
        [Theory]
        [InlineData(FilePathTest.CAFETEIRA_PATH, "6108")]
        [InlineData(FilePathTest.LIVRO_PATH, "outronamespace")]
        public void NormalOperation(string path, string expected)
        {
            try
            {
                var nfeDetail = ClassicConverter.GetDetail(path);
                var cfop = nfeDetail.prod.CFOP;
                Assert.Equal(expected, cfop);
            }
            catch (System.Exception ex)
            {
                Assert.IsType<System.InvalidOperationException>(ex);
                Assert.Contains(expected, ex.InnerException.Message);
            }
        }
    }
}