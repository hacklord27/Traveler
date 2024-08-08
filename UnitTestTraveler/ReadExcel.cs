using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestTraveler
{
    class ReadExcel
    {
        private string excelFilePath;

        public ReadExcel(string filePath)
        {
            excelFilePath = filePath;
        }
        // Tạo một thể hiện của lớp ReadExcel và truyền đường dẫn của tệp Excel vào constructor
        string excelFilePath = @"C:\Users\tusvu\OneDrive\Desktop\test.xlsx"; // Đường dẫn tới tệp Excel của bạn
        ReadExcel excelReader = new ReadExcel(excelFilePath);

        // Bây giờ bạn có thể sử dụng thể hiện excelReader để đọc dữ liệu từ tệp Excel

        public List<TestInputData> ReadTestData()
        {
            List<TestInputData> testDataList = new List<TestInputData>();

            using (var stream = File.Open(excelFilePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet();
                    var table = result.Tables[0];

                    // Bắt đầu từ dòng thứ hai, bỏ qua dòng tiêu đề
                    for (int i = 1; i < table.Rows.Count; i++)
                    {
                        var userName = Convert.ToString(table.Rows[i][0]);
                        var phoneNumber = Convert.ToString(table.Rows[i][1]);
                        var email = Convert.ToString(table.Rows[i][2]);
                        var password = Convert.ToString(table.Rows[i][3]);
                        var rePassword = Convert.ToString(table.Rows[i][4]);
                        var expectedMessage = Convert.ToString(table.Rows[i][5]);

                        testDataList.Add(new TestInputData(userName, phoneNumber, email, password, rePassword, expectedMessage));
                    }
                }
            }

            return testDataList;
        }
    }
}
