using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using ProductoCrud.Model;

namespace ProductoCrud
{
    public class SQLiteHelper
    {
        private readonly SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<ProductoModel>();
        }
        public Task<int> CreateProducto(ProductoModel Producto)
        {
            return db.InsertAsync(Producto);
        }
        public Task<List<ProductoModel>> ReadProductos()
        {
            return db.Table<ProductoModel>().ToListAsync();
        }
        public Task<int> UpdateProducto(ProductoModel Producto)
        {
            return db.UpdateAsync(Producto);
        }
        public Task<int> DeleteProducto(ProductoModel Producto)
        {
            return db.DeleteAsync(Producto);
        }
        public Task<List<ProductoModel>> Search(string search)
        {
            return db.Table<ProductoModel>().Where(p => p.Nombre.StartsWith(search)).ToListAsync();
        }
    }
}
