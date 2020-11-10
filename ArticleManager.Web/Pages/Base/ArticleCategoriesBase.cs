﻿using ArticleManager.Core.Models;
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

        protected ItemDetailsModel<ArticleCategoryItem> categoryModel = new ItemDetailsModel<ArticleCategoryItem>()
        {
            ItemName = "Category"
        };

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
            categoryModel.Item = null;
        }

        public async Task AddCategory()
        {
            categoryModel.Item = await service.GetNew();
        }

        public async Task EditCategory(object item)
        {
            categoryModel.Item = await service.Get(((ArticleCategoryListItem)item).Id);
        }

        public async Task SaveCategory()
        {
            try
            {
                if (categoryModel.Item.Id == 0)
                {
                    await service.Create(categoryModel.Item);
                }
                else
                {
                    await service.Update(categoryModel.Item);
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
