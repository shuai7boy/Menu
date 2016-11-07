using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace MP.Common.Enums
{
    public class EnumHelper : System.Attribute
    {
        private string _Author = string.Empty;
        private string _Description = string.Empty;
        private string _Url = string.Empty;

        /// <summary>
        /// 构造方法
        /// </summary>
        public EnumHelper()
        {
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="description">描述</param>
        public EnumHelper(string description)
        {
            _Description = description;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="author">作者</param>
        /// <param name="description">描述</param>
        /// <param name="url">相关的Url</param>
        public EnumHelper(string author, string description, string url)
        {
            _Author = author;
            _Description = description;
            _Url = url;
        }

        /// <summary>
        /// 描述作者
        /// </summary>
        public string Author
        {
            get
            {
                return _Author;
            }
            set
            {
                _Author = value;
            }
        }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }

        /// <summary>
        /// 相关的Url
        /// </summary>
        public string Url
        {
            get
            {
                return _Url;
            }
            set
            {
                _Url = value;
            }
        }

        /// <summary>
        /// 得到某一个枚举项的RemarkAttribute
        /// </summary>
        /// <param name="en">枚举项</param>
        /// <returns>RemarkAttribute对象</returns>
        private EnumHelper GetRemarkAttributeFromEnumItem(System.Enum en)
        {
            Type type = en.GetType();
            FieldInfo f = type.GetField(en.ToString());

            EnumHelper ra = (EnumHelper)Attribute.GetCustomAttribute(f, typeof(EnumHelper));

            return ra;
        }

        /// <summary>
        /// 得到某一个枚举项的Remark描述
        /// </summary>
        /// <param name="en">枚举项</param>
        /// <returns>Remark的描述</returns>
        private string GetRemarkStringFromEnumItem(System.Enum en)
        {
            EnumHelper ra = GetRemarkAttributeFromEnumItem(en);

            string strDesp = string.Empty;

            if (ra != null)
                strDesp = ra.Description;
            else
                strDesp = en.ToString();

            return strDesp;
        }
        /// <summary>
        /// 根据当前枚举值获取Remark值
        /// </summary>
        /// <param name="enumType">类型</param>
        /// <param name="enumValue">值</param>
        /// <returns></returns>
        public string GetEnumName(Type enumType, string enumValue)
        {
            return GetRemarkStringFromEnumItem(
                (Enum)Enum.Parse(enumType, enumValue));
        }
        #region 使用枚举说明来填充下拉列表

        /// <summary>
        /// 使用枚举说明来填充下拉列表。
        /// </summary>
        /// <param name="ddl">下拉列表控件。</param>
        /// <param name="enumType"></param>
        public void SetEnumDropDownList(DropDownList ddl, Type enumType)
        {
            string[] nameList = Enum.GetNames(enumType);
            Array valueList = Enum.GetValues(enumType);
            for (int i = 0; i < nameList.Length; i++)
            {
                string typeName = GetRemarkStringFromEnumItem(
                    (Enum)Enum.Parse(enumType, nameList[i]));
                string typeValue = ((int)((IList)valueList)[i]).ToString();
                ddl.Items.Add(new ListItem(typeName, typeValue));
            }

        }

        /// <summary>
        /// 使用枚举说明来填充下拉列表。
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="notShow">不显示的项的编号</param>
        public string SetEnumSelect(Type enumType, string notShow = "")
        {
            string selectList = string.Empty;
            string[] nameList = Enum.GetNames(enumType);
            Array valueList = Enum.GetValues(enumType);
            for (int i = 0; i < nameList.Length; i++)
            {
                string typeName = GetRemarkStringFromEnumItem(
                    (Enum)Enum.Parse(enumType, nameList[i]));
                string typeValue = ((int)((IList)valueList)[i]).ToString();
                if (notShow != "")
                {
                    string[] not = notShow.Split(',');

                    if (!((IList)not).Contains(typeValue))
                    {
                        selectList += " <option value='" + typeValue + "'>" + typeName + "</option>";
                    }
                }
                else
                {
                    selectList += " <option value='" + typeValue + "'>" + typeName + "</option>";
                }
            }
            return selectList;
        }

        public string GetEnumList(Type enumType)
        {
            string[] nameList = Enum.GetNames(enumType);
            string html = string.Empty;
            for (int i = 0; i < nameList.Length; i++)
            {
                if (html.Length > 0)
                {
                    html += "," + GetRemarkStringFromEnumItem(
                          (Enum)Enum.Parse(enumType, nameList[i]));

                }
                else
                {
                    html = GetRemarkStringFromEnumItem(
                    (Enum)Enum.Parse(enumType, nameList[i]));
                }
            }
            return html;
        }

        #endregion

    }
}
