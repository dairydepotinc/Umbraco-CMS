using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Models;
using umbraco;

namespace Umbraco.Web.Cache
{
    /// <summary>
    /// Extension methods for DistrubutedCache
    /// </summary>
    public static class DistributedCacheExtensions
    {
        #region User cache
        public static void RemoveUserCache(this DistributedCache dc, int userId)
        {
            dc.Remove(new Guid(DistributedCache.UserCacheRefresherId), userId);
        }

        public static void RefreshUserCache(this DistributedCache dc, int userId)
        {
            dc.Refresh(new Guid(DistributedCache.UserCacheRefresherId), userId);
        } 
        #endregion

        #region Template cache
        /// <summary>
        /// Refreshes the cache amongst servers for a template
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="templateId"></param>
        public static void RefreshTemplateCache(this DistributedCache dc, int templateId)
        {
            dc.Refresh(new Guid(DistributedCache.TemplateRefresherId), templateId);
        }

        /// <summary>
        /// Removes the cache amongst servers for a template
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="templateId"></param>
        public static void RemoveTemplateCache(this DistributedCache dc, int templateId)
        {
            dc.Remove(new Guid(DistributedCache.TemplateRefresherId), templateId);
        } 
        #endregion

        #region Page cache
        /// <summary>
        /// Refreshes the cache amongst servers for all pages
        /// </summary>
        /// <param name="dc"></param>
        public static void RefreshAllPageCache(this DistributedCache dc)
        {
            dc.RefreshAll(new Guid(DistributedCache.PageCacheRefresherId));
        }

        /// <summary>
        /// Refreshes the cache amongst servers for a page
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="documentId"></param>
        public static void RefreshPageCache(this DistributedCache dc, int documentId)
        {
            dc.Refresh(new Guid(DistributedCache.PageCacheRefresherId), documentId);
        }

        /// <summary>
        /// Refreshes page cache for all instances passed in
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="content"></param>
        public static void RefreshPageCache(this DistributedCache dc, params IContent[] content)
        {
            dc.Refresh(new Guid(DistributedCache.PageCacheRefresherId), x => x.Id, content);
        }

        /// <summary>
        /// Removes the cache amongst servers for a page
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="content"></param>
        public static void RemovePageCache(this DistributedCache dc, params IContent[] content)
        {
            dc.Remove(new Guid(DistributedCache.PageCacheRefresherId), x => x.Id, content);
        }

        /// <summary>
        /// Removes the cache amongst servers for a page
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="documentId"></param>
        public static void RemovePageCache(this DistributedCache dc, int documentId)
        {
            dc.Remove(new Guid(DistributedCache.PageCacheRefresherId), documentId);
        } 
        #endregion

        #region Member cache
        /// <summary>
        /// Refreshes the cache amongst servers for a member
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="memberId"></param>
        public static void RefreshMemberCache(this DistributedCache dc, int memberId)
        {
            dc.Refresh(new Guid(DistributedCache.MemberCacheRefresherId), memberId);
        }

        /// <summary>
        /// Removes the cache amongst servers for a member
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="memberId"></param>
        public static void RemoveMemberCache(this DistributedCache dc, int memberId)
        {
            dc.Remove(new Guid(DistributedCache.MemberCacheRefresherId), memberId);
        } 
        #endregion

        #region Media Cache
        /// <summary>
        /// Refreshes the cache amongst servers for a media item
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="mediaId"></param>
        public static void RefreshMediaCache(this DistributedCache dc, int mediaId)
        {
            dc.Refresh(new Guid(DistributedCache.MediaCacheRefresherId), mediaId);
        }

        /// <summary>
        /// Refreshes the cache amongst servers for a media item
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="media"></param>
        public static void RefreshMediaCache(this DistributedCache dc, params IMedia[] media)
        {
            dc.Refresh(new Guid(DistributedCache.MediaCacheRefresherId), x => x.Id, media);
        }

        /// <summary>
        /// Removes the cache amongst servers for a media item
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="mediaId"></param>
        public static void RemoveMediaCache(this DistributedCache dc, int mediaId)
        {
            dc.Remove(new Guid(DistributedCache.MediaCacheRefresherId), mediaId);
        }

        /// <summary>
        /// Removes the cache amongst servers for media items
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="media"></param>
        public static void RemoveMediaCache(this DistributedCache dc, params IMedia[] media)
        {
            dc.Remove(new Guid(DistributedCache.MediaCacheRefresherId), x => x.Id, media);
        } 
        #endregion

        #region Macro Cache

        /// <summary>
        /// Clears the cache for all macros on the current server
        /// </summary>
        /// <param name="dc"></param>
        public static void ClearAllMacroCacheOnCurrentServer(this DistributedCache dc)
        {
            //NOTE: The 'false' ensure that it will only refresh on the current server, not post to all servers
            dc.RefreshAll(new Guid(DistributedCache.MacroCacheRefresherId), false);
        }
        
        /// <summary>
        /// Refreshes the cache amongst servers for a macro item
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="macroId"></param>
        public static void RefreshMacroCache(this DistributedCache dc, int macroId)
        {
            dc.Refresh(new Guid(DistributedCache.MacroCacheRefresherId), macroId);
        }

        /// <summary>
        /// Refreshes the cache amongst servers for a macro item
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="macro"></param>
        public static void RefreshMacroCache(this DistributedCache dc, global::umbraco.cms.businesslogic.macro.Macro macro)
        {
            if (macro != null)
            {
                dc.Refresh(new Guid(DistributedCache.MacroCacheRefresherId), macro1 => macro1.Id, macro);
            }
        }

        /// <summary>
        /// Removes the cache amongst servers for a macro item
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="macroId"></param>
        public static void RemoveMacroCache(this DistributedCache dc, int macroId)
        {
            dc.Remove(new Guid(DistributedCache.MacroCacheRefresherId), macroId);
        }

        /// <summary>
        /// Removes the cache amongst servers for a macro item
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="macro"></param>
        public static void RemoveMacroCache(this DistributedCache dc, global::umbraco.cms.businesslogic.macro.Macro macro)
        {
            if (macro != null)
            {
                dc.Remove(new Guid(DistributedCache.MacroCacheRefresherId), macro1 => macro1.Id, macro);
            }
        }

        /// <summary>
        /// Removes the cache amongst servers for a macro item
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="macro"></param>
        public static void RemoveMacroCache(this DistributedCache dc, macro macro)
        {
            if (macro != null && macro.Model != null)
            {
                dc.Remove(new Guid(DistributedCache.MacroCacheRefresherId), macro1 => macro1.Model.Id, macro);
            }
        } 
        #endregion

        #region Content type cache

        /// <summary>
        /// Remove all cache for a given content type
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="contentType"></param>
        public static void RefreshContentTypeCache(this DistributedCache dc, IContentType contentType)
        {
            if (contentType != null)
            {
                //dc.Refresh(new Guid(DistributedCache.ContentTypeCacheRefresherId), x => x.Id, contentType);
                dc.RefreshByJson(new Guid(DistributedCache.ContentTypeCacheRefresherId),
                    ContentTypeCacheRefresher.SerializeToJsonPayload(false, contentType));
            }
        }

        /// <summary>
        /// Remove all cache for a given media type
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="mediaType"></param>
        public static void RefreshMediaTypeCache(this DistributedCache dc, IMediaType mediaType)
        {
            if (mediaType != null)
            {
                //dc.Refresh(new Guid(DistributedCache.ContentTypeCacheRefresherId), x => x.Id, mediaType);
                dc.RefreshByJson(new Guid(DistributedCache.ContentTypeCacheRefresherId),
                    ContentTypeCacheRefresher.SerializeToJsonPayload(false, mediaType));
            }
        }

        /// <summary>
        /// Remove all cache for a given content type
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="contentType"></param>
        public static void RemoveContentTypeCache(this DistributedCache dc, IContentType contentType)
        {
            if (contentType != null)
            {
                //dc.Remove(new Guid(DistributedCache.ContentTypeCacheRefresherId), x => x.Id, contentType);
                dc.RemoveByJson(new Guid(DistributedCache.ContentTypeCacheRefresherId),
                    ContentTypeCacheRefresher.SerializeToJsonPayload(true, contentType));
            }
        }

        /// <summary>
        /// Remove all cache for a given media type
        /// </summary>
        /// <param name="dc"></param>
        /// <param name="mediaType"></param>
        public static void RemoveMediaTypeCache(this DistributedCache dc, IMediaType mediaType)
        {
            if (mediaType != null)
            {
                //dc.Remove(new Guid(DistributedCache.ContentTypeCacheRefresherId), x => x.Id, mediaType);
                dc.RemoveByJson(new Guid(DistributedCache.ContentTypeCacheRefresherId),
                    ContentTypeCacheRefresher.SerializeToJsonPayload(true, mediaType));
            }
        } 
        #endregion

        public static void ClearXsltCacheOnCurrentServer(this DistributedCache dc)
        {
            if (UmbracoSettings.UmbracoLibraryCacheDuration > 0)
            {
                ApplicationContext.Current.ApplicationCache.ClearCacheObjectTypes("MS.Internal.Xml.XPath.XPathSelectionIterator");
            }
        }
    }
}