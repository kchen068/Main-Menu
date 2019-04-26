using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection;

namespace UnityUITable
{

	[ExecuteInEditMode]
	public abstract class TableCell : MonoBehaviour
	{

		CellContainer _container;
		public CellContainer container
		{
			get
			{
				if (_container == null)
					_container = transform.parent.GetComponent<CellContainer>();
				if (_container == null)
					_container = transform.parent.parent.parent.GetComponent<CellContainer>();
				return _container;
			}
		}

		public Table table { get { return container.table; } }
		public TableColumn column { get { return container.column; } }

		MemberInfo _member;
		protected MemberInfo member
		{
			get
			{
				if (_member == null)
					_member = columnInfo.GetMember();
				return _member;
			}
		}
		public int elmtIndex { get { return container.rowIndex - 1; } }
		public object obj { get { return table.GetSortedElements()[elmtIndex]; } }

		public TableColumnInfo columnInfo { get { return container.columnInfo; } }
		protected TableCellStyle cellStyle { get { return columnInfo.CellStyle; } }

		PropertyOrFieldInfo _property;
		protected PropertyOrFieldInfo property
		{
			get
			{
				if (_property == null) _property = new PropertyOrFieldInfo(member);
				return _property;
			}
		}

		public virtual Type StyleType { get { return null; } }

		protected static bool IsOfCompatibleType(MemberInfo member, params Type[] compatibleTypes)
		{
			return compatibleTypes != null && compatibleTypes.Any(t => t.IsAssignableFrom(PropertyOrFieldInfo.GetPropertyOrFieldType(member)));
		}

		public abstract bool IsCompatibleWithMember(MemberInfo member);

		/// <summary>
		/// Override to define the priority of the cell type, depending on the member associated.
		/// </summary>
		/// <returns>The priority</returns>
		/// <param name="member">The member associated with this column.</param>
		public virtual int GetPriority(MemberInfo member)
		{
			return 0;
		}

		public void Initialize()
		{
			UpdateContent();
			UpdateStyle();
		}

		public abstract void UpdateContent();

		public virtual void UpdateStyle() { }

		public bool IsRightCellType
		{
			get
			{
				return name.StartsWith(columnInfo.CellPrefab.name);
			}
		}

	}

}
