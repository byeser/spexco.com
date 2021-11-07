using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TagBuilder = System.Web.Mvc.TagBuilder;

namespace spexco.com.ui.utils
{
    public class ExtendedSelectListItem : Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
    {
        public optgroupItem optgroupItem { get; set; }
        public object HtmlAttributes { get; set; }
    }
    public class optgroupItem
    {
        public string Label { get; set; }
        public object HtmlAttributes { get; set; }
    }
    public static class ExtendedSelectExtensions
    {
        internal static object GetModelStateValue(this IHtmlHelper htmlHelper, string key, Type destinationType)
        {
            Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry modelState;
            //Microsoft.AspNetCore.Mvc.ModelBinding.ValueProviderResult asas;

            if (htmlHelper.ViewData.ModelState.TryGetValue(key, out modelState))
            {
                if (modelState.RawValue != null)
                {
                    return modelState.GetModelStateForProperty(destinationType.ToString());

                    //  return modelState.Value.ConvertTo(destinationType, null /* culture */);
                }
            }
            return null;
        }

        public static HtmlString ExtendedDropDownList(this IHtmlHelper htmlHelper, string name, IEnumerable<ExtendedSelectListItem> selectList)
        {
            return ExtendedDropDownList(htmlHelper, name, selectList, (IDictionary<string, object>)null);
        }

        public static HtmlString ExtendedDropDownList(this IHtmlHelper htmlHelper, string name, IEnumerable<ExtendedSelectListItem> selectList, IDictionary<string, object> htmlAttributes)
        {
            return ExtendedDropDownListHelper(htmlHelper, null, name, selectList, htmlAttributes);
        }

        public static HtmlString ExtendedDropDownListHelper(this IHtmlHelper htmlHelper, Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata metadata, string expression, IEnumerable<ExtendedSelectListItem> selectList, IDictionary<string, object> htmlAttributes)
        {
            return SelectInternal(htmlHelper, metadata, expression, selectList, false, htmlAttributes, false);
        }

        public static HtmlString ExtendedDropDownListFor<TModel, TProperty>(this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, IEnumerable<ExtendedSelectListItem> selectList,
            object htmlAttributes, bool is_multiple = false, bool is_group = false)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");
            var metadata = ExpressionMetadataProvider.FromLambdaExpression(expression, htmlHelper.ViewData, htmlHelper.MetadataProvider);

            //Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata metadata = Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata.FromLambdaExpression<TModel, TProperty>(expression, htmlHelper.ViewData);
            return SelectInternal(htmlHelper, null, ExpressionHelper.GetExpressionText(expression), selectList,
                is_multiple /* allowMultiple */, AnonymousObjectToHtmlAttributes(htmlAttributes), is_group);
        }

        private static HtmlString SelectInternal(this IHtmlHelper htmlHelper, Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata metadata, string name,
            IEnumerable<ExtendedSelectListItem> selectList, bool allowMultiple,
            IDictionary<string, object> htmlAttributes, bool is_group)
        {
            string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (String.IsNullOrEmpty(fullName))
                throw new ArgumentException("No name");

            if (selectList == null)
                throw new ArgumentException("No selectlist");

            object defaultValue = (allowMultiple)
                ? htmlHelper.GetModelStateValue(fullName, typeof(string[]))
                : htmlHelper.GetModelStateValue(fullName, typeof(string));

            // If we haven't already used ViewData to get the entire list of items then we need to
            // use the ViewData-supplied value before using the parameter-supplied value.
            if (defaultValue == null)
                defaultValue = htmlHelper.ViewData.Eval(fullName);



            if (defaultValue != null)
            {
                IEnumerable defaultValues = (allowMultiple) ? defaultValue as IEnumerable : new[] { defaultValue };
                IEnumerable<string> values = from object value in defaultValues
                                             select Convert.ToString(value, CultureInfo.CurrentCulture);
                HashSet<string> selectedValues = new HashSet<string>(values, StringComparer.OrdinalIgnoreCase);
                List<ExtendedSelectListItem> newSelectList = new List<ExtendedSelectListItem>();

                foreach (ExtendedSelectListItem item in selectList)
                {
                    //item.Selected = (item.Value != null)
                    //    ? selectedValues.Contains(item.Value)
                    //    : selectedValues.Contains(item.Text);
                    newSelectList.Add(item);
                }
                selectList = newSelectList;
            }

            #region create select tag
            TagBuilder select_builder = new TagBuilder("select");
            //select_builder.MergeAttributes(htmlAttributes);
            select_builder.MergeAttribute("name", fullName, true /* replaceExisting */);
            select_builder.GenerateId(fullName);
            if (allowMultiple)
                select_builder.MergeAttribute("multiple", "multiple");

            // If there are any errors for a named field, we add the css attribute.
            Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry modelState;
            if (htmlHelper.ViewData.ModelState.TryGetValue(fullName, out modelState))
            {
                if (modelState.Errors.Count > 0)
                {
                    select_builder.AddCssClass(System.Web.WebPages.Html.HtmlHelper.ValidationInputCssClassName);
                }
            }
            if (htmlAttributes.ContainsKey("class") == true)
            {
                string data = "dropdown-select form-control " + htmlAttributes["class"].ToString();
                select_builder.MergeAttribute("class", data);

            }
            else
            {
                string data = "dropdown-select form-control";
                select_builder.MergeAttribute("class", data);
            }
            if (htmlAttributes.ContainsKey("disabled") == true)
            {
                select_builder.MergeAttribute("disabled", "");

            }
            if (htmlAttributes.ContainsKey("required") == true)
                select_builder.MergeAttribute("required", "");
            //select_builder.MergeAttributes(MergeHtmlAttributes(htmlHelper, htmlAttributes, metadata));//htmlHelper.GetEnumSelectList(fullName, metadata)

            select_builder.InnerHtml += ListItemToOption(new ExtendedSelectListItem() { Text = string.Empty, Value = string.Empty, Selected = false }).ToString();
            #endregion


            if (is_group)
            {
                var groups = selectList.GroupBy(x => x.optgroupItem.Label, (Key, g) => new { group = g.FirstOrDefault(), list = g.ToArray() });
                foreach (var g in groups)
                {
                    var group_builder = new TagBuilder("optgroup");
                    group_builder.Attributes["label"] = g.group.optgroupItem.Label;
                    group_builder.MergeAttributes(AnonymousObjectToHtmlAttributes(g.group.optgroupItem.HtmlAttributes));

                    var list_builder = new StringBuilder();
                    foreach (var l in g.list)
                    {
                        list_builder.Append(ListItemToOption(l));
                    }
                    group_builder.InnerHtml = list_builder.ToString();
                    select_builder.InnerHtml += group_builder.ToString(System.Web.Mvc.TagRenderMode.Normal);
                }
            }
            else
            {
                var list_builder = new StringBuilder();
                foreach (var l in selectList)
                {
                    list_builder.Append(ListItemToOption(l));
                }
                select_builder.InnerHtml += list_builder.ToString();
            }

            return new HtmlString(select_builder.ToString(System.Web.Mvc.TagRenderMode.Normal));
        }

        internal static string ListItemToOption(ExtendedSelectListItem item)
        {

            TagBuilder builder = new TagBuilder("option")
            {
                InnerHtml = HttpUtility.HtmlEncode(item.Text)
            };
            if (item.Value != null)
            {
                builder.Attributes["value"] = item.Value;
            }
            if (item.Selected)
            {
                builder.Attributes["selected"] = "selected";
            }
            if (item.HtmlAttributes != null && item.HtmlAttributes.ToString().Contains("data_"))
            {
                var data = item.HtmlAttributes.ToString().Replace("{", "").Replace("}", "");
                var sp = data.Split(new string[] { ", data_" }, StringSplitOptions.None);
                var dict = new Dictionary<string, object>();
                for (int i = 0; i < sp.Length; i++)
                {
                    var sub_sb = sp[i].Split('=');
                    if (sub_sb[0].Contains("data_i18n"))
                    {
                        builder.MergeAttributes(AnonymousObjectToHtmlAttributes(item.HtmlAttributes, true));
                        return builder.ToString(System.Web.Mvc.TagRenderMode.Normal);
                    }
                    if (sub_sb[0].Contains("data_"))
                        dict.Add(sub_sb[0].Replace(" ", "").Replace("_", "-"), sub_sb[1]);
                    else
                        dict.Add("data-" + sub_sb[0].Replace(" ", ""), sub_sb[1]);
                }
                builder.MergeAttributes(dict);
                return builder.ToString(System.Web.Mvc.TagRenderMode.Normal);
            }

            builder.MergeAttributes(AnonymousObjectToHtmlAttributes(item.HtmlAttributes, true));
            return builder.ToString(System.Web.Mvc.TagRenderMode.Normal);
        }

        internal static string ListItemToOptionGroup(ExtendedSelectListItem item)
        {
            TagBuilder builder = new TagBuilder("optgroup");
            if (item.optgroupItem != null)
            {
                builder.Attributes["label"] = item.optgroupItem.Label;
            }
            builder.MergeAttributes(AnonymousObjectToHtmlAttributes(item.optgroupItem.HtmlAttributes, true));
            return builder.ToString(System.Web.Mvc.TagRenderMode.Normal);
        }
        private static IDictionary<string, object> AnonymousObjectToHtmlAttributes(object htmlAttributes, bool att = false)
        {
            if (att == true && htmlAttributes != null)
            {
                var t = htmlAttributes.ToString().Replace("{", "").Replace("}", "").Replace(" ", "").Split('=');
                return new Dictionary<string, object>() { { t[0].Replace("_", "-"), t[1] } };
            }

            var dictionary = htmlAttributes as IDictionary<string, object>;
            if (dictionary != null)
            {
                return new Dictionary<string, object>(dictionary, StringComparer.OrdinalIgnoreCase);
            }

            dictionary = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

            if (htmlAttributes != null)
            {
                var stringAttributes = htmlAttributes.ToString();
                stringAttributes = stringAttributes.Replace("{", "").Replace("}", "");
                string[] attributesArray = stringAttributes.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var helper in attributesArray)
                {
                    string[] attribKeyValue = helper.Trim().Split(' ');
                    dictionary[attribKeyValue.First()] = attribKeyValue.Last();
                }
            }
            // dictionary["class"] = "dropdown-select form-control";
            return dictionary;
        }
        public static IDictionary<string, object> MergeHtmlAttributes(this IHtmlHelper helper, object htmlAttributesObject, object defaultHtmlAttributesObject)
        {
            var concatKeys = new[] { "class" };

            var htmlAttributesDict = htmlAttributesObject as IDictionary<string, object>;
            var defaultHtmlAttributesDict = defaultHtmlAttributesObject as IDictionary<string, object>;

            RouteValueDictionary htmlAttributes = new RouteValueDictionary(htmlAttributesDict != null
                ? htmlAttributesDict
                : AnonymousObjectToHtmlAttributes(htmlAttributesObject));

            RouteValueDictionary defaultHtmlAttributes = new RouteValueDictionary(defaultHtmlAttributesDict != null
                ? defaultHtmlAttributesDict
                : AnonymousObjectToHtmlAttributes(defaultHtmlAttributesObject));

            foreach (var item in htmlAttributes)
            {
                if (concatKeys.Contains(item.Key))
                {
                    defaultHtmlAttributes[item.Key] = defaultHtmlAttributes[item.Key] != null
                        ? string.Format("{0} {1}", defaultHtmlAttributes[item.Key], item.Value)
                        : item.Value;
                }
                else
                {
                    if (item.Key == "divClass")
                    {
                        continue;
                    }
                    defaultHtmlAttributes[item.Key] = item.Value;
                }
            }

            return defaultHtmlAttributes;
        }
    }
    internal static class ExpressionMetadataProvider
    {
        public static ModelExplorer FromLambdaExpression<TModel, TResult>(
            Expression<Func<TModel, TResult>> expression,
            Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TModel> viewData,
            IModelMetadataProvider metadataProvider)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            if (viewData == null)
            {
                throw new ArgumentNullException(nameof(viewData));
            }

            string propertyName = null;
            Type containerType = null;
            var legalExpression = false;

            // Need to verify the expression is valid; it needs to at least end in something
            // that we can convert to a meaningful string for model binding purposes

            switch (expression.Body.NodeType)
            {
                case ExpressionType.ArrayIndex:
                    // ArrayIndex always means a single-dimensional indexer;
                    // multi-dimensional indexer is a method call to Get().
                    legalExpression = true;
                    break;

                case ExpressionType.MemberAccess:
                    // Property/field access is always legal
                    var memberExpression = (MemberExpression)expression.Body;
                    propertyName = memberExpression.Member is System.Reflection.PropertyInfo ? memberExpression.Member.Name : null;
                    if (string.Equals(propertyName, "Model", StringComparison.Ordinal) &&
                        memberExpression.Type == typeof(TModel) &&
                        memberExpression.Expression.NodeType == ExpressionType.Constant)
                    {
                        // Special case the Model property in RazorPage<TModel>. (m => Model) should behave identically
                        // to (m => m). But do the more complicated thing for (m => m.Model) since that is a slightly
                        // different beast.)
                        return FromModel(viewData, metadataProvider);
                    }

                    // memberExpression.Expression can be null when this is a static field or property.
                    //
                    // This can be the case if the expression is like (m => Person.Name) where Name is a static field
                    // or property on the Person type.
                    containerType = memberExpression.Expression?.Type;

                    legalExpression = true;
                    break;

                case ExpressionType.Parameter:
                    // Parameter expression means "model => model", so we delegate to FromModel
                    return FromModel(viewData, metadataProvider);
            }

            if (!legalExpression)
            {
                throw new InvalidOperationException("TemplateLimitations");
            }

            object modelAccessor(object container)
            {
                var model = (TModel)container;
                var func = expression.Compile();
                try
                {
                    return func(model);
                }
                catch (NullReferenceException)
                {
                    return null;
                }
            }

            Microsoft.AspNetCore.Mvc.ModelBinding.ModelMetadata metadata = null;
            if (containerType != null && propertyName != null)
            {
                // Ex:
                //    m => m.Color (simple property access)
                //    m => m.Color.Red (nested property access)
                //    m => m.Widgets[0].Size (expression ending with property-access)
                metadata = metadataProvider.GetMetadataForType(containerType).Properties[propertyName];
            }

            if (metadata == null)
            {
                // Ex:
                //    m => 5 (arbitrary expression)
                //    m => foo (arbitrary expression)
                //    m => m.Widgets[0] (expression ending with non-property-access)
                //
                // This can also happen for any case where we cannot retrieve a model metadata.
                // This will happen for:
                // - fields
                // - statics
                // - non-visibility (internal/private)
                metadata = metadataProvider.GetMetadataForType(typeof(TResult));
                System.Diagnostics.Debug.Assert(metadata != null);
            }

            return viewData.ModelExplorer.GetExplorerForExpression(metadata, modelAccessor);
        }

        /// <summary>
        /// Gets <see cref="ModelExplorer"/> for named <paramref name="expression"/> in given
        /// <paramref name="viewData"/>.
        /// </summary>
        /// <param name="expression">Expression name, relative to <c>viewData.Model</c>.</param>
        /// <param name="viewData">
        /// The <see cref="ViewDataDictionary"/> that may contain the <paramref name="expression"/> value.
        /// </param>
        /// <param name="metadataProvider">The <see cref="IModelMetadataProvider"/>.</param>
        /// <returns>
        /// <see cref="ModelExplorer"/> for named <paramref name="expression"/> in given <paramref name="viewData"/>.
        /// </returns>
        public static ModelExplorer FromStringExpression(
            string expression,
            Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary viewData,
            IModelMetadataProvider metadataProvider)
        {
            if (viewData == null)
            {
                throw new ArgumentNullException(nameof(viewData));
            }

            var viewDataInfo = ViewDataEvaluator.Eval(viewData, expression);
            if (viewDataInfo == null)
            {
                // Try getting a property from ModelMetadata if we couldn't find an answer in ViewData
                var propertyExplorer = viewData.ModelExplorer.GetExplorerForProperty(expression);
                if (propertyExplorer != null)
                {
                    return propertyExplorer;
                }
            }

            if (viewDataInfo != null)
            {
                if (viewDataInfo.Container == viewData &&
                    viewDataInfo.Value == viewData.Model &&
                    string.IsNullOrEmpty(expression))
                {
                    // Nothing for empty expression in ViewData and ViewDataEvaluator just returned the model. Handle
                    // using FromModel() for its object special case.
                    return FromModel(viewData, metadataProvider);
                }

                ModelExplorer containerExplorer = viewData.ModelExplorer;
                if (viewDataInfo.Container != null)
                {
                    containerExplorer = metadataProvider.GetModelExplorerForType(
                        viewDataInfo.Container.GetType(),
                        viewDataInfo.Container);
                }

                if (viewDataInfo.PropertyInfo != null)
                {
                    // We've identified a property access, which provides us with accurate metadata.
                    var containerMetadata = metadataProvider.GetMetadataForType(viewDataInfo.Container.GetType());
                    var propertyMetadata = containerMetadata.Properties[viewDataInfo.PropertyInfo.Name];

                    Func<object, object> modelAccessor = (ignore) => viewDataInfo.Value;
                    return containerExplorer.GetExplorerForExpression(propertyMetadata, modelAccessor);
                }
                else if (viewDataInfo.Value != null)
                {
                    // We have a value, even though we may not know where it came from.
                    var valueMetadata = metadataProvider.GetMetadataForType(viewDataInfo.Value.GetType());
                    return containerExplorer.GetExplorerForExpression(valueMetadata, viewDataInfo.Value);
                }
            }

            // Treat the expression as string if we don't find anything better.
            var stringMetadata = metadataProvider.GetMetadataForType(typeof(string));
            return viewData.ModelExplorer.GetExplorerForExpression(stringMetadata, modelAccessor: null);
        }

        private static ModelExplorer FromModel(
            Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary viewData,
            IModelMetadataProvider metadataProvider)
        {
            if (viewData == null)
            {
                throw new ArgumentNullException(nameof(viewData));
            }

            if (viewData.ModelMetadata.ModelType == typeof(object))
            {
                // Use common simple type rather than object so e.g. Editor() at least generates a TextBox.
                var model = viewData.Model == null ? null : Convert.ToString(viewData.Model, CultureInfo.CurrentCulture);
                return metadataProvider.GetModelExplorerForType(typeof(string), model);
            }
            else
            {
                return viewData.ModelExplorer;
            }
        }
    }
}