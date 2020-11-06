using ArticleManager.Core.Models;
using ArticleManager.Web.Services;
using Microsoft.AspNetCore.Components;
using Pin.Web.Blazor.Models;
using System;
using System.Threading.Tasks;

namespace ArticleManager.Web.Pages
{
    public partial class Articles: ComponentBase
    {
        private ItemListModel articlesModel = new ItemListModel()
        {
            ItemName = "Article",
            Headers = new string[] { "Id", "Title", "Category" },
            Items = new ArticleListItem[0]
        };

        private ArticleItem currentArticle;
        private string error;

        [Inject]
        private ICRUDService<ArticleListItem, ArticleItem> service { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await ShowList();
        }

        public async Task ShowList()
        {
            articlesModel.Items = await service.GetList();
            currentArticle = null;
        }

        public async Task AddArticle()
        {
            currentArticle = await service.GetNew();
        }

        public async Task EditArticle(object item)
        {
            currentArticle = await service.Get(((ArticleListItem)item).Id);
        }

        public async Task SaveArticle(object item)
        {
            try
            {
                if (currentArticle.Id == 0)
                {
                    await service.Create(currentArticle);
                }
                else
                {
                    await service.Update(currentArticle);
                }
                await this.ShowList();
            }
            catch (Exception ex)
            {
                this.error = ex.Message;
            }
        }

        public async Task DeleteArticle(object item)
        {
            try
            {
                await service.Delete(((ArticleListItem)item).Id);
                await this.ShowList();
            }
            catch (Exception ex)
            {
                this.error = ex.Message;
            }
        }
    }
}
