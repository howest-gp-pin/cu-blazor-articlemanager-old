using ArticleManager.Core.Models;
using ArticleManager.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using Pin.Web.Blazor.Models;

namespace ArticleManager.Web.Pages.Base
{
    public class ArticleCategoriesBase: ComponentBase
    {
        protected ItemListModel categoriesModel = new ItemListModel()
        {
            ItemName = "Category",
            Headers = new string[] { "Id", "Name" },
            Items = new ArticleCategoryListItem[0]
        };

        protected ArticleCategoryItem currentCategory;
        protected string error;

        [Inject]
        private ICRUDService<ArticleCategoryListItem, ArticleCategoryItem> service { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await ShowList();
        }

        public async Task ShowList()
        {
            categoriesModel.Items = await service.GetList();
            currentCategory = null;
        }

        public async Task AddCategory()
        {
            currentCategory = await service.GetNew();
        }

        public async Task EditCategory(object item)
        {
            currentCategory = await service.Get(((ArticleCategoryListItem)item).Id);
        }

        public async Task SaveCategory()
        {
            try
            {
                if (currentCategory.Id == 0)
                {
                    await service.Create(currentCategory);
                }
                else
                {
                    await service.Update(currentCategory);
                }
                await this.ShowList();
            }
            catch (Exception ex)
            {
                this.error = ex.Message;
            }
        }

        public async Task DeleteCategory(object item)
        {
            try
            {
                await service.Delete(((ArticleCategoryListItem)item).Id);
                await this.ShowList();
            }
            catch (Exception ex)
            {
                this.error = ex.Message;
            }
        }
    }
}
