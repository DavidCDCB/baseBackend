using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projectSoft.Entities;
using projectSoft.Interfaces;

//https://github.com/ttu/json-flatfile-datastore
using JsonFlatFileDataStore;

namespace projectSoft.Repositories
{
	public class PublicacionRepository : IPublicacionRepository
	{
		// Todas las tablas van a estar almacenadas de manera ordenada en un JSON
		public const string PATCH = "./Data/jsonDB.json";
		public DataStore store = new DataStore(PATCH);

		/*
		Busca un elemento a partir de un id espefificado por url
		GET http://localhost:5000/api/Publicacion/102
		*/
		public Publicacion GetPublicacion(int id)
		{
			try
			{
				var collection = store.GetCollection<Publicacion>();
				var results = collection.AsQueryable().First(x=>x.IdPublicacion==id);
				return results;
			}
			catch (System.InvalidOperationException)
			{
				return null;
			}
		}

		/*
		Genera una lista de todos los elementos almacenados
		GET http://localhost:5000/api/Publicacion
		*/
		public IEnumerable<Publicacion> GetPublicaciones()
		{
			var collection = store.GetCollection<Publicacion>();
			var results = collection.AsQueryable();
			
			return results;
		}

		/*
		Almacena una lista de elementos pasada por POST en formato json
		POST http://localhost:5000/api/Publicacion
		*/
		public async Task<IEnumerable<Publicacion>> SetPublicacionAsync(List<Publicacion> publicaciones)
		{
			var collection = store.GetCollection<Publicacion>();
			List<int> ids=collection.AsQueryable().Select(x=>x.IdPublicacion).ToList();
			int nId = ids.Max();

			foreach (var item in publicaciones)
			{
				item.IdPublicacion = ++nId;
				await collection.InsertOneAsync(item);
			}
			
			return publicaciones;
		}

		/*
		Actualiza un elemento especificado por id y pasado por json
		PUT http://localhost:5000/api/Publicacion/102
		*/
		public async Task<Publicacion> UpdatePublicacion(int id, Publicacion publicacion)
		{
			Publicacion actual = this.GetPublicacion(id);

			if(actual != null){
				var collection = store.GetCollection<Publicacion>();
				await collection.ReplaceOneAsync(e => e.IdPublicacion == id,publicacion);
			}
			return actual;
		}

		/*
		Elimina un elemento especificado por id en la url
		DELETE http://localhost:5000/api/Publicacion/102
		*/
		public async Task<Publicacion> RemovePublicacion(int id)
		{
			Publicacion actual = this.GetPublicacion(id);

			if(actual != null){
				var collection = store.GetCollection<Publicacion>();
				await collection.DeleteOneAsync(e => e.IdPublicacion == id);
			}
			return actual;
		}
	}
}