using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

namespace SoSmartTv.VideoFilesProvider.TorrentFileNameParser
{
	public static class TorrenVideoFileParser
	{
		public static TorrentVideoFileInfo Parse(string torrentFileName)
		{
			var dto = new TorrentVideoFileInfo();
			foreach (var pattern in TorrentVideoFileNamingPattern.Patterns)
			{
				torrentFileName = torrentFileName.ParsePatterns(dto, pattern.Key, pattern.Value);
			}
			dto.Title = torrentFileName.ParseTitle();
			return dto;
		}

		private static string ParseTitle(this string torrentFileName)
		{
			return torrentFileName.TrimEnd('.', ' ').Replace('.', ' ').Split(new[] { "  " }, StringSplitOptions.RemoveEmptyEntries)[0];
		}

		private static string ParsePatterns(this string torrentFileName, TorrentVideoFileInfo dto, Expression<Func<TorrentVideoFileInfo, object>> property,
			string pattern)
		{
			var result = Regex.Match(torrentFileName, pattern);
			if (result.Success)
			{
				var match = result.Groups.Count > 1 ? result.Groups[2].Value : result.Groups[0].Value;
				var raw = result.Groups.Count > 1 ? result.Groups[1].Value : result.Groups[0].Value;

				if (TryAssignValue(dto, property, match))
					torrentFileName = string.Join("", torrentFileName.Split(new[] { raw }, StringSplitOptions.RemoveEmptyEntries));
			}
			return torrentFileName;
		}

		public static bool TryAssignValue(TorrentVideoFileInfo dto, Expression<Func<TorrentVideoFileInfo, object>> property, string match)
		{
			var key = (property.Body is MemberExpression)
				? (property.Body as MemberExpression).Member.Name
				: ((property.Body as UnaryExpression).Operand as MemberExpression).Member.Name;

			var dtoExpression = Expression.Constant(dto);
			var propertyExpression = Expression.PropertyOrField(dtoExpression, key);
			if (!TryGetConvertExpression(match, propertyExpression.Type))
				return false;
			var matchExpression = Expression.Constant(match);
			var convertExpression = GetConvertExpression(matchExpression, propertyExpression.Type);
			var assignExpression = Expression.Assign(propertyExpression, convertExpression);
			var lambda = Expression.Lambda(assignExpression);
			var compiledExpression = lambda.Compile();
			compiledExpression.DynamicInvoke();
			return true;
		}

		private static bool TryGetConvertExpression(string value, Type propertyType)
		{
			if (propertyType == typeof(string))
				return true;
			if (propertyType == typeof(bool))
				return true;
			if (propertyType == typeof(int))
			{
				int x;
				return int.TryParse(value, out x);
			}
			throw new NotSupportedException(string.Format("Type {0} is not supported", propertyType));
		}

		private static Expression GetConvertExpression(Expression leftExpression, Type propertyType)
		{
			if (propertyType == typeof(string))
				return leftExpression;
			if (propertyType == typeof(bool))
				return Expression.Constant(true);
			if (propertyType == typeof(int))
				return Expression.Call(typeof(Convert).GetMethod("ToInt32", new[] { typeof(string) }), leftExpression);
			throw new NotSupportedException(string.Format("Type {0} is not supported", propertyType));
		}
	}
}