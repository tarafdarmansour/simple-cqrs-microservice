using Nest;
using ProductSearchService.Domain;
using ProductSearchService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductSearchService.DataAccess.ElasticSearch
{
    public class ProductRepository : IProductSearchRepository
    {
        private readonly ElasticClient elasticClient;

        public ProductRepository(ElasticClient elasticClient)
        {
            this.elasticClient = elasticClient;
        }

        public async Task Add(SearchProduct searchProduct)
        {
            try
            {
                var res = await elasticClient.IndexDocumentAsync(searchProduct);
            }
            catch (Exception exp)
            {
            }
        }

        public async Task Delete(SearchProduct searchProduct)
        {
            try
            {
                var res = await elasticClient
                        .DeleteAsync<SearchProduct>(searchProduct);
            }
            catch (Exception exp)
            {

            }
        }

        public async Task<List<SearchProduct>> Find(string queryText)
        {
            var result = await elasticClient
                .SearchAsync<SearchProduct>(
                    s =>
                        s.From(0)
                        //.Size(10)
                        .Query(q =>
                            q.MultiMatch(mm =>
                                mm.Query(queryText)
                                .Fields(f => f.Fields(p => p.Name, p => p.CategoryName, p => p.Manufacturer))
                                .Type(TextQueryType.BestFields)
                                .Fuzziness(Fuzziness.Auto)
                            )
                    ));


            return result.Documents.ToList();
        }

        public async Task<SearchProduct> GetById(Guid Id)
        {
            var result = await elasticClient
                .GetAsync<SearchProduct>(Id);


            return result.Source;
        }


        public async Task Update(SearchProduct searchProduct)
        {
            try
            {
                var res = await elasticClient
                        .UpdateAsync<SearchProduct>(searchProduct.Id, u => u.Doc(searchProduct));
            }
            catch (Exception exp)
            {

            }
        }
    }
}
