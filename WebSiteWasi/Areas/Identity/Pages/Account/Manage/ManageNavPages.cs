// Licenciado a la .NET Foundation bajo uno o más acuerdos.
// La .NET Foundation te licencia este archivo bajo la licencia MIT.
#nullable disable

using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebSiteWasi.Areas.Identity.Pages.Account.Manage
{
    /// <summary>
    ///     Esta API admite la infraestructura de la interfaz de usuario predeterminada de ASP.NET Core Identity y no está destinada a ser utilizada
    ///     directamente desde tu código. Esta API puede cambiar o eliminarse en futuras versiones.
    /// </summary>
    public static class ManageNavPages
    {
        /// <summary>
        ///     Esta API admite la infraestructura de la interfaz de usuario predeterminada de ASP.NET Core Identity y no está destinada a ser utilizada
        ///     directamente desde tu código. Esta API puede cambiar o eliminarse en futuras versiones.
        /// </summary>
        public static string Index => "Índice";

        /// <summary>
        ///     Esta API admite la infraestructura de la interfaz de usuario predeterminada de ASP.NET Core Identity y no está destinada a ser utilizada
        ///     directamente desde tu código. Esta API puede cambiar o eliminarse en futuras versiones.
        /// </summary>
        public static string Email => "Correo electrónico";

        /// <summary>
        ///     Esta API admite la infraestructura de la interfaz de usuario predeterminada de ASP.NET Core Identity y no está destinada a ser utilizada
        ///     directamente desde tu código. Esta API puede cambiar o eliminarse en futuras versiones.
        /// </summary>
        public static string ChangePassword => "CambiarContraseña";

        /// <summary>
        ///     Esta API admite la infraestructura de la interfaz de usuario predeterminada de ASP.NET Core Identity y no está destinada a ser utilizada
        ///     directamente desde tu código. Esta API puede cambiar o eliminarse en futuras versiones.
        /// </summary>
        public static string DownloadPersonalData => "DescargarDatosPersonales";

        /// <summary>
        ///     Esta API admite la infraestructura de la interfaz de usuario predeterminada de ASP.NET Core Identity y no está destinada a ser utilizada
        ///     directamente desde tu código. Esta API puede cambiar o eliminarse en futuras versiones.
        /// </summary>
        public static string DeletePersonalData => "EliminarDatosPersonales";

        /// <summary>
        ///     Esta API admite la infraestructura de la interfaz de usuario predeterminada de ASP.NET Core Identity y no está destinada a ser utilizada
        ///     directamente desde tu código. Esta API puede cambiar o eliminarse en futuras versiones.
        /// </summary>
        public static string ExternalLogins => "IniciosDeSesiónExternos";

        /// <summary>
        ///     Esta API admite la infraestructura de la interfaz de usuario predeterminada de ASP.NET Core Identity y no está destinada a ser utilizada
        ///     directamente desde tu código. Esta API puede cambiar o eliminarse en futuras versiones.
        /// </summary>
        public static string PersonalData => "DatosPersonales";

        /// <summary>
        ///     Esta API admite la infraestructura de la interfaz de usuario predeterminada de ASP.NET Core Identity y no está destinada a ser utilizada
        ///     directamente desde tu código. Esta API puede cambiar o eliminarse en futuras versiones.
        /// </summary>
        public static string TwoFactorAuthentication => "AutenticaciónDeDosFactores";

        /// <summary>
        ///     Esta API admite la infraestructura de la interfaz de usuario predeterminada de ASP.NET Core Identity y no está destinada a ser utilizada
        ///     directamente desde tu código. Esta API puede cambiar o eliminarse en futuras versiones.
        /// </summary>
        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);

        /// <summary>
        ///     Esta API admite la infraestructura de la interfaz de usuario predeterminada de ASP.NET Core Identity y no está destinada a ser utilizada
        ///     directamente desde tu código. Esta API puede cambiar o eliminarse en futuras versiones.
        /// </summary>
        public static string EmailNavClass(ViewContext viewContext) => PageNavClass(viewContext, Email);

        /// <summary>
        ///     Esta API admite la infraestructura de la interfaz de usuario predeterminada de ASP.NET Core Identity y no está destinada a ser utilizada
        ///     directamente desde tu código. Esta API puede cambiar o eliminarse en futuras versiones.
        /// </summary>
        public static string ChangePasswordNavClass(ViewContext viewContext) => PageNavClass(viewContext, ChangePassword);

        /// <summary>
        ///     Esta API admite la infraestructura de la interfaz de usuario predeterminada de ASP.NET Core Identity y no está destinada a ser utilizada
        ///     directamente desde tu código. Esta API puede cambiar o eliminarse en futuras versiones.
        /// </summary>
        public static string DownloadPersonalDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, DownloadPersonalData);

        /// <summary>
        ///     Esta API admite la infraestructura de la interfaz de usuario predeterminada de ASP.NET Core Identity y no está destinada a ser utilizada
        ///     directamente desde tu código. Esta API puede cambiar o eliminarse en futuras versiones.
        /// </summary>
        public static string DeletePersonalDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, DeletePersonalData);

        /// <summary>
        ///     Esta API admite la infraestructura de la interfaz de usuario predeterminada de ASP.NET Core Identity y no está destinada a ser utilizada
        ///     directamente desde tu código. Esta API puede cambiar o eliminarse en futuras versiones.
        /// </summary>
        public static string ExternalLoginsNavClass(ViewContext viewContext) => PageNavClass(viewContext, ExternalLogins);

        /// <summary>
        ///     Esta API admite la infraestructura de la interfaz de usuario predeterminada de ASP.NET Core Identity y no está destinada a ser utilizada
        ///     directamente desde tu código. Esta API puede cambiar o eliminarse en futuras versiones.
        /// </summary>
        public static string PersonalDataNavClass(ViewContext viewContext) => PageNavClass(viewContext, PersonalData);

        /// <summary>
        ///     Esta API admite la infraestructura de la interfaz de usuario predeterminada de ASP.NET Core Identity y no está destinada a ser utilizada
        ///     directamente desde tu código. Esta API puede cambiar o eliminarse en futuras versiones.
        /// </summary>
        public static string TwoFactorAuthenticationNavClass(ViewContext viewContext) => PageNavClass(viewContext, TwoFactorAuthentication);

        /// <summary>
        ///     Esta API admite la infraestructura de la interfaz de usuario predeterminada de ASP.NET Core Identity y no está destinada a ser utilizada
        ///     directamente desde tu código. Esta API puede cambiar o eliminarse en futuras versiones.
        /// </summary>
        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
