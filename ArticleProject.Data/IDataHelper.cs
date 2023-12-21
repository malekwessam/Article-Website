using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.Data
{
    public interface IDataHelper<Table>
    {
        List<Table> GetAllData();
        List<Table> GetDataByUser(string UserId);
        List<Table> Search(string SearchItem);
        Table Find(int Id);

        int Add(Table table);
        int Update(int Id,Table table);
        int Delete(int Id);
    }
}
