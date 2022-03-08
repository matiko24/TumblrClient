using System;
using MvvmCross.DroidX.RecyclerView.ItemTemplates;
using TumblrClient.Core.Utils;
using TumblrClient.Core.ViewModels.PostsViewModels;

namespace TumblrClient.Droid.Utils
{
    public class PostTemplateSelector : MvxTemplateSelector<PostViewModel>
    {
        public override int GetItemLayoutId(int fromViewType)
        {
            return fromViewType;
        }

        protected override int SelectItemViewType(PostViewModel forItemObject)
        {
            return forItemObject.Type switch
            {
                PostType.Text => Resource.Layout.item_text_post,
                PostType.Link => Resource.Layout.item_link_post,
                PostType.Quote => Resource.Layout.item_quote_post,
                PostType.Photo => Resource.Layout.item_photo_post,
                _ => throw new NotImplementedException()
            };
        }
    }
}
