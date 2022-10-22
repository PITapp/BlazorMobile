using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SinDarElaMobile.Data;

namespace SinDarElaMobile
{
    public partial class ExportDbSinDarElaController : ExportController
    {
        private readonly DbSinDarElaContext context;
        public ExportDbSinDarElaController(DbSinDarElaContext context)
        {
            this.context = context;
        }

        [HttpGet("/export/DbSinDarEla/abrechnungbases/csv")]
        [HttpGet("/export/DbSinDarEla/abrechnungbases/csv(fileName='{fileName}')")]
        public FileStreamResult ExportAbrechnungBasesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.AbrechnungBases, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/abrechnungbases/excel")]
        [HttpGet("/export/DbSinDarEla/abrechnungbases/excel(fileName='{fileName}')")]
        public FileStreamResult ExportAbrechnungBasesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.AbrechnungBases, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/abrechnungkundenreststundens/csv")]
        [HttpGet("/export/DbSinDarEla/abrechnungkundenreststundens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportAbrechnungKundenReststundensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.AbrechnungKundenReststundens, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/abrechnungkundenreststundens/excel")]
        [HttpGet("/export/DbSinDarEla/abrechnungkundenreststundens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportAbrechnungKundenReststundensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.AbrechnungKundenReststundens, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/aufgabens/csv")]
        [HttpGet("/export/DbSinDarEla/aufgabens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportAufgabensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Aufgabens, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/aufgabens/excel")]
        [HttpGet("/export/DbSinDarEla/aufgabens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportAufgabensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Aufgabens, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/auswahljahrs/csv")]
        [HttpGet("/export/DbSinDarEla/auswahljahrs/csv(fileName='{fileName}')")]
        public FileStreamResult ExportAuswahlJahrsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.AuswahlJahrs, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/auswahljahrs/excel")]
        [HttpGet("/export/DbSinDarEla/auswahljahrs/excel(fileName='{fileName}')")]
        public FileStreamResult ExportAuswahlJahrsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.AuswahlJahrs, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/auswahlmonats/csv")]
        [HttpGet("/export/DbSinDarEla/auswahlmonats/csv(fileName='{fileName}')")]
        public FileStreamResult ExportAuswahlMonatsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.AuswahlMonats, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/auswahlmonats/excel")]
        [HttpGet("/export/DbSinDarEla/auswahlmonats/excel(fileName='{fileName}')")]
        public FileStreamResult ExportAuswahlMonatsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.AuswahlMonats, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/bases/csv")]
        [HttpGet("/export/DbSinDarEla/bases/csv(fileName='{fileName}')")]
        public FileStreamResult ExportBasesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Bases, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/bases/excel")]
        [HttpGet("/export/DbSinDarEla/bases/excel(fileName='{fileName}')")]
        public FileStreamResult ExportBasesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Bases, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/baseanredens/csv")]
        [HttpGet("/export/DbSinDarEla/baseanredens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportBaseAnredensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.BaseAnredens, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/baseanredens/excel")]
        [HttpGet("/export/DbSinDarEla/baseanredens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportBaseAnredensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.BaseAnredens, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/basekontaktes/csv")]
        [HttpGet("/export/DbSinDarEla/basekontaktes/csv(fileName='{fileName}')")]
        public FileStreamResult ExportBaseKontaktesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.BaseKontaktes, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/basekontaktes/excel")]
        [HttpGet("/export/DbSinDarEla/basekontaktes/excel(fileName='{fileName}')")]
        public FileStreamResult ExportBaseKontaktesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.BaseKontaktes, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/benutzers/csv")]
        [HttpGet("/export/DbSinDarEla/benutzers/csv(fileName='{fileName}')")]
        public FileStreamResult ExportBenutzersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Benutzers, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/benutzers/excel")]
        [HttpGet("/export/DbSinDarEla/benutzers/excel(fileName='{fileName}')")]
        public FileStreamResult ExportBenutzersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Benutzers, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/benutzermodules/csv")]
        [HttpGet("/export/DbSinDarEla/benutzermodules/csv(fileName='{fileName}')")]
        public FileStreamResult ExportBenutzerModulesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.BenutzerModules, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/benutzermodules/excel")]
        [HttpGet("/export/DbSinDarEla/benutzermodules/excel(fileName='{fileName}')")]
        public FileStreamResult ExportBenutzerModulesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.BenutzerModules, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/benutzerprotokolls/csv")]
        [HttpGet("/export/DbSinDarEla/benutzerprotokolls/csv(fileName='{fileName}')")]
        public FileStreamResult ExportBenutzerProtokollsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.BenutzerProtokolls, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/benutzerprotokolls/excel")]
        [HttpGet("/export/DbSinDarEla/benutzerprotokolls/excel(fileName='{fileName}')")]
        public FileStreamResult ExportBenutzerProtokollsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.BenutzerProtokolls, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/debuggs/csv")]
        [HttpGet("/export/DbSinDarEla/debuggs/csv(fileName='{fileName}')")]
        public FileStreamResult ExportDebuggsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Debuggs, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/debuggs/excel")]
        [HttpGet("/export/DbSinDarEla/debuggs/excel(fileName='{fileName}')")]
        public FileStreamResult ExportDebuggsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Debuggs, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/devicecodes/csv")]
        [HttpGet("/export/DbSinDarEla/devicecodes/csv(fileName='{fileName}')")]
        public FileStreamResult ExportDeviceCodesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.DeviceCodes, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/devicecodes/excel")]
        [HttpGet("/export/DbSinDarEla/devicecodes/excel(fileName='{fileName}')")]
        public FileStreamResult ExportDeviceCodesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.DeviceCodes, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/dokumentes/csv")]
        [HttpGet("/export/DbSinDarEla/dokumentes/csv(fileName='{fileName}')")]
        public FileStreamResult ExportDokumentesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Dokumentes, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/dokumentes/excel")]
        [HttpGet("/export/DbSinDarEla/dokumentes/excel(fileName='{fileName}')")]
        public FileStreamResult ExportDokumentesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Dokumentes, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/dokumentekategoriens/csv")]
        [HttpGet("/export/DbSinDarEla/dokumentekategoriens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportDokumenteKategoriensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.DokumenteKategoriens, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/dokumentekategoriens/excel")]
        [HttpGet("/export/DbSinDarEla/dokumentekategoriens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportDokumenteKategoriensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.DokumenteKategoriens, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/ereignisses/csv")]
        [HttpGet("/export/DbSinDarEla/ereignisses/csv(fileName='{fileName}')")]
        public FileStreamResult ExportEreignissesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Ereignisses, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/ereignisses/excel")]
        [HttpGet("/export/DbSinDarEla/ereignisses/excel(fileName='{fileName}')")]
        public FileStreamResult ExportEreignissesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Ereignisses, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/ereignisseartens/csv")]
        [HttpGet("/export/DbSinDarEla/ereignisseartens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportEreignisseArtensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.EreignisseArtens, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/ereignisseartens/excel")]
        [HttpGet("/export/DbSinDarEla/ereignisseartens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportEreignisseArtensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.EreignisseArtens, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/ereignissesonderurlaubartens/csv")]
        [HttpGet("/export/DbSinDarEla/ereignissesonderurlaubartens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportEreignisseSonderurlaubArtensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.EreignisseSonderurlaubArtens, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/ereignissesonderurlaubartens/excel")]
        [HttpGet("/export/DbSinDarEla/ereignissesonderurlaubartens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportEreignisseSonderurlaubArtensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.EreignisseSonderurlaubArtens, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/ereignisseteilnehmers/csv")]
        [HttpGet("/export/DbSinDarEla/ereignisseteilnehmers/csv(fileName='{fileName}')")]
        public FileStreamResult ExportEreignisseTeilnehmersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.EreignisseTeilnehmers, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/ereignisseteilnehmers/excel")]
        [HttpGet("/export/DbSinDarEla/ereignisseteilnehmers/excel(fileName='{fileName}')")]
        public FileStreamResult ExportEreignisseTeilnehmersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.EreignisseTeilnehmers, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/ereignisseteilnehmerstatuses/csv")]
        [HttpGet("/export/DbSinDarEla/ereignisseteilnehmerstatuses/csv(fileName='{fileName}')")]
        public FileStreamResult ExportEreignisseTeilnehmerStatusesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.EreignisseTeilnehmerStatuses, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/ereignisseteilnehmerstatuses/excel")]
        [HttpGet("/export/DbSinDarEla/ereignisseteilnehmerstatuses/excel(fileName='{fileName}')")]
        public FileStreamResult ExportEreignisseTeilnehmerStatusesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.EreignisseTeilnehmerStatuses, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/feedbacks/csv")]
        [HttpGet("/export/DbSinDarEla/feedbacks/csv(fileName='{fileName}')")]
        public FileStreamResult ExportFeedbacksToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Feedbacks, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/feedbacks/excel")]
        [HttpGet("/export/DbSinDarEla/feedbacks/excel(fileName='{fileName}')")]
        public FileStreamResult ExportFeedbacksToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Feedbacks, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/firmens/csv")]
        [HttpGet("/export/DbSinDarEla/firmens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportFirmensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Firmens, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/firmens/excel")]
        [HttpGet("/export/DbSinDarEla/firmens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportFirmensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Firmens, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/firmenmitarbeitertaetigkeitens/csv")]
        [HttpGet("/export/DbSinDarEla/firmenmitarbeitertaetigkeitens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportFirmenMitarbeiterTaetigkeitensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.FirmenMitarbeiterTaetigkeitens, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/firmenmitarbeitertaetigkeitens/excel")]
        [HttpGet("/export/DbSinDarEla/firmenmitarbeitertaetigkeitens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportFirmenMitarbeiterTaetigkeitensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.FirmenMitarbeiterTaetigkeitens, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/infotextehtmls/csv")]
        [HttpGet("/export/DbSinDarEla/infotextehtmls/csv(fileName='{fileName}')")]
        public FileStreamResult ExportInfotexteHtmlsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.InfotexteHtmls, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/infotextehtmls/excel")]
        [HttpGet("/export/DbSinDarEla/infotextehtmls/excel(fileName='{fileName}')")]
        public FileStreamResult ExportInfotexteHtmlsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.InfotexteHtmls, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/kundens/csv")]
        [HttpGet("/export/DbSinDarEla/kundens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportKundensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Kundens, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/kundens/excel")]
        [HttpGet("/export/DbSinDarEla/kundens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportKundensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Kundens, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/kundenkontaktes/csv")]
        [HttpGet("/export/DbSinDarEla/kundenkontaktes/csv(fileName='{fileName}')")]
        public FileStreamResult ExportKundenKontaktesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.KundenKontaktes, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/kundenkontaktes/excel")]
        [HttpGet("/export/DbSinDarEla/kundenkontaktes/excel(fileName='{fileName}')")]
        public FileStreamResult ExportKundenKontaktesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.KundenKontaktes, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/kundenkontakteartens/csv")]
        [HttpGet("/export/DbSinDarEla/kundenkontakteartens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportKundenKontakteArtensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.KundenKontakteArtens, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/kundenkontakteartens/excel")]
        [HttpGet("/export/DbSinDarEla/kundenkontakteartens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportKundenKontakteArtensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.KundenKontakteArtens, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/kundenleistungartens/csv")]
        [HttpGet("/export/DbSinDarEla/kundenleistungartens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportKundenLeistungArtensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.KundenLeistungArtens, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/kundenleistungartens/excel")]
        [HttpGet("/export/DbSinDarEla/kundenleistungartens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportKundenLeistungArtensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.KundenLeistungArtens, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/kundenleistungens/csv")]
        [HttpGet("/export/DbSinDarEla/kundenleistungens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportKundenLeistungensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.KundenLeistungens, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/kundenleistungens/excel")]
        [HttpGet("/export/DbSinDarEla/kundenleistungens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportKundenLeistungensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.KundenLeistungens, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/kundenleistungenbescheides/csv")]
        [HttpGet("/export/DbSinDarEla/kundenleistungenbescheides/csv(fileName='{fileName}')")]
        public FileStreamResult ExportKundenLeistungenBescheidesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.KundenLeistungenBescheides, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/kundenleistungenbescheides/excel")]
        [HttpGet("/export/DbSinDarEla/kundenleistungenbescheides/excel(fileName='{fileName}')")]
        public FileStreamResult ExportKundenLeistungenBescheidesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.KundenLeistungenBescheides, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/kundenleistungenbescheidekontingentes/csv")]
        [HttpGet("/export/DbSinDarEla/kundenleistungenbescheidekontingentes/csv(fileName='{fileName}')")]
        public FileStreamResult ExportKundenLeistungenBescheideKontingentesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.KundenLeistungenBescheideKontingentes, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/kundenleistungenbescheidekontingentes/excel")]
        [HttpGet("/export/DbSinDarEla/kundenleistungenbescheidekontingentes/excel(fileName='{fileName}')")]
        public FileStreamResult ExportKundenLeistungenBescheideKontingentesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.KundenLeistungenBescheideKontingentes, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/kundenleistungenbescheidestatuses/csv")]
        [HttpGet("/export/DbSinDarEla/kundenleistungenbescheidestatuses/csv(fileName='{fileName}')")]
        public FileStreamResult ExportKundenLeistungenBescheideStatusesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.KundenLeistungenBescheideStatuses, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/kundenleistungenbescheidestatuses/excel")]
        [HttpGet("/export/DbSinDarEla/kundenleistungenbescheidestatuses/excel(fileName='{fileName}')")]
        public FileStreamResult ExportKundenLeistungenBescheideStatusesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.KundenLeistungenBescheideStatuses, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/kundenleistungenbetreuers/csv")]
        [HttpGet("/export/DbSinDarEla/kundenleistungenbetreuers/csv(fileName='{fileName}')")]
        public FileStreamResult ExportKundenLeistungenBetreuersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.KundenLeistungenBetreuers, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/kundenleistungenbetreuers/excel")]
        [HttpGet("/export/DbSinDarEla/kundenleistungenbetreuers/excel(fileName='{fileName}')")]
        public FileStreamResult ExportKundenLeistungenBetreuersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.KundenLeistungenBetreuers, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/kundenleistungenbetreuerartens/csv")]
        [HttpGet("/export/DbSinDarEla/kundenleistungenbetreuerartens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportKundenLeistungenBetreuerArtensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.KundenLeistungenBetreuerArtens, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/kundenleistungenbetreuerartens/excel")]
        [HttpGet("/export/DbSinDarEla/kundenleistungenbetreuerartens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportKundenLeistungenBetreuerArtensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.KundenLeistungenBetreuerArtens, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/kundenstatuses/csv")]
        [HttpGet("/export/DbSinDarEla/kundenstatuses/csv(fileName='{fileName}')")]
        public FileStreamResult ExportKundenStatusesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.KundenStatuses, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/kundenstatuses/excel")]
        [HttpGet("/export/DbSinDarEla/kundenstatuses/excel(fileName='{fileName}')")]
        public FileStreamResult ExportKundenStatusesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.KundenStatuses, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/mitarbeiters/csv")]
        [HttpGet("/export/DbSinDarEla/mitarbeiters/csv(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeitersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Mitarbeiters, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/mitarbeiters/excel")]
        [HttpGet("/export/DbSinDarEla/mitarbeiters/excel(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeitersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Mitarbeiters, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/mitarbeiterartens/csv")]
        [HttpGet("/export/DbSinDarEla/mitarbeiterartens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterArtensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.MitarbeiterArtens, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/mitarbeiterartens/excel")]
        [HttpGet("/export/DbSinDarEla/mitarbeiterartens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterArtensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.MitarbeiterArtens, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/mitarbeiterfirmens/csv")]
        [HttpGet("/export/DbSinDarEla/mitarbeiterfirmens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterFirmensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.MitarbeiterFirmens, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/mitarbeiterfirmens/excel")]
        [HttpGet("/export/DbSinDarEla/mitarbeiterfirmens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterFirmensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.MitarbeiterFirmens, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/mitarbeiterfortbildungens/csv")]
        [HttpGet("/export/DbSinDarEla/mitarbeiterfortbildungens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterFortbildungensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.MitarbeiterFortbildungens, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/mitarbeiterfortbildungens/excel")]
        [HttpGet("/export/DbSinDarEla/mitarbeiterfortbildungens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterFortbildungensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.MitarbeiterFortbildungens, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/mitarbeiterfortbildungenartens/csv")]
        [HttpGet("/export/DbSinDarEla/mitarbeiterfortbildungenartens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterFortbildungenArtensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.MitarbeiterFortbildungenArtens, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/mitarbeiterfortbildungenartens/excel")]
        [HttpGet("/export/DbSinDarEla/mitarbeiterfortbildungenartens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterFortbildungenArtensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.MitarbeiterFortbildungenArtens, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/mitarbeiterkundenbudgets/csv")]
        [HttpGet("/export/DbSinDarEla/mitarbeiterkundenbudgets/csv(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterKundenbudgetsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.MitarbeiterKundenbudgets, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/mitarbeiterkundenbudgets/excel")]
        [HttpGet("/export/DbSinDarEla/mitarbeiterkundenbudgets/excel(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterKundenbudgetsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.MitarbeiterKundenbudgets, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/mitarbeiterkundenbudgetkategoriens/csv")]
        [HttpGet("/export/DbSinDarEla/mitarbeiterkundenbudgetkategoriens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterKundenbudgetKategoriensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.MitarbeiterKundenbudgetKategoriens, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/mitarbeiterkundenbudgetkategoriens/excel")]
        [HttpGet("/export/DbSinDarEla/mitarbeiterkundenbudgetkategoriens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterKundenbudgetKategoriensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.MitarbeiterKundenbudgetKategoriens, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/mitarbeiterstatuses/csv")]
        [HttpGet("/export/DbSinDarEla/mitarbeiterstatuses/csv(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterStatusesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.MitarbeiterStatuses, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/mitarbeiterstatuses/excel")]
        [HttpGet("/export/DbSinDarEla/mitarbeiterstatuses/excel(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterStatusesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.MitarbeiterStatuses, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/mitarbeitertaetigkeitens/csv")]
        [HttpGet("/export/DbSinDarEla/mitarbeitertaetigkeitens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterTaetigkeitensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.MitarbeiterTaetigkeitens, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/mitarbeitertaetigkeitens/excel")]
        [HttpGet("/export/DbSinDarEla/mitarbeitertaetigkeitens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterTaetigkeitensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.MitarbeiterTaetigkeitens, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/mitarbeitertaetigkeitenartens/csv")]
        [HttpGet("/export/DbSinDarEla/mitarbeitertaetigkeitenartens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterTaetigkeitenArtensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.MitarbeiterTaetigkeitenArtens, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/mitarbeitertaetigkeitenartens/excel")]
        [HttpGet("/export/DbSinDarEla/mitarbeitertaetigkeitenartens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterTaetigkeitenArtensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.MitarbeiterTaetigkeitenArtens, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/mitarbeiterurlaubs/csv")]
        [HttpGet("/export/DbSinDarEla/mitarbeiterurlaubs/csv(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterUrlaubsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.MitarbeiterUrlaubs, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/mitarbeiterurlaubs/excel")]
        [HttpGet("/export/DbSinDarEla/mitarbeiterurlaubs/excel(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterUrlaubsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.MitarbeiterUrlaubs, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/mitarbeiterurlaubdetails/csv")]
        [HttpGet("/export/DbSinDarEla/mitarbeiterurlaubdetails/csv(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterUrlaubDetailsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.MitarbeiterUrlaubDetails, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/mitarbeiterurlaubdetails/excel")]
        [HttpGet("/export/DbSinDarEla/mitarbeiterurlaubdetails/excel(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterUrlaubDetailsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.MitarbeiterUrlaubDetails, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/mitarbeiterurlaubkumuliertanspruches/csv")]
        [HttpGet("/export/DbSinDarEla/mitarbeiterurlaubkumuliertanspruches/csv(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterUrlaubKumuliertAnspruchesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.MitarbeiterUrlaubKumuliertAnspruches, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/mitarbeiterurlaubkumuliertanspruches/excel")]
        [HttpGet("/export/DbSinDarEla/mitarbeiterurlaubkumuliertanspruches/excel(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterUrlaubKumuliertAnspruchesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.MitarbeiterUrlaubKumuliertAnspruches, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/mitarbeiterurlaubkumuliertdienstzeitens/csv")]
        [HttpGet("/export/DbSinDarEla/mitarbeiterurlaubkumuliertdienstzeitens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterUrlaubKumuliertDienstzeitensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.MitarbeiterUrlaubKumuliertDienstzeitens, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/mitarbeiterurlaubkumuliertdienstzeitens/excel")]
        [HttpGet("/export/DbSinDarEla/mitarbeiterurlaubkumuliertdienstzeitens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterUrlaubKumuliertDienstzeitensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.MitarbeiterUrlaubKumuliertDienstzeitens, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/mitarbeiterverlaufdienstzeitens/csv")]
        [HttpGet("/export/DbSinDarEla/mitarbeiterverlaufdienstzeitens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterVerlaufDienstzeitensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.MitarbeiterVerlaufDienstzeitens, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/mitarbeiterverlaufdienstzeitens/excel")]
        [HttpGet("/export/DbSinDarEla/mitarbeiterverlaufdienstzeitens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterVerlaufDienstzeitensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.MitarbeiterVerlaufDienstzeitens, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/mitarbeiterverlaufdienstzeitenartens/csv")]
        [HttpGet("/export/DbSinDarEla/mitarbeiterverlaufdienstzeitenartens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterVerlaufDienstzeitenArtensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.MitarbeiterVerlaufDienstzeitenArtens, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/mitarbeiterverlaufdienstzeitenartens/excel")]
        [HttpGet("/export/DbSinDarEla/mitarbeiterverlaufdienstzeitenartens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterVerlaufDienstzeitenArtensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.MitarbeiterVerlaufDienstzeitenArtens, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/mitarbeiterverlaufgehalts/csv")]
        [HttpGet("/export/DbSinDarEla/mitarbeiterverlaufgehalts/csv(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterVerlaufGehaltsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.MitarbeiterVerlaufGehalts, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/mitarbeiterverlaufgehalts/excel")]
        [HttpGet("/export/DbSinDarEla/mitarbeiterverlaufgehalts/excel(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterVerlaufGehaltsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.MitarbeiterVerlaufGehalts, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/mitarbeiterverlaufnormalarbeitszeits/csv")]
        [HttpGet("/export/DbSinDarEla/mitarbeiterverlaufnormalarbeitszeits/csv(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterVerlaufNormalarbeitszeitsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.MitarbeiterVerlaufNormalarbeitszeits, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/mitarbeiterverlaufnormalarbeitszeits/excel")]
        [HttpGet("/export/DbSinDarEla/mitarbeiterverlaufnormalarbeitszeits/excel(fileName='{fileName}')")]
        public FileStreamResult ExportMitarbeiterVerlaufNormalarbeitszeitsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.MitarbeiterVerlaufNormalarbeitszeits, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/mitteilungens/csv")]
        [HttpGet("/export/DbSinDarEla/mitteilungens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportMitteilungensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Mitteilungens, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/mitteilungens/excel")]
        [HttpGet("/export/DbSinDarEla/mitteilungens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportMitteilungensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Mitteilungens, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/mitteilungenverteilers/csv")]
        [HttpGet("/export/DbSinDarEla/mitteilungenverteilers/csv(fileName='{fileName}')")]
        public FileStreamResult ExportMitteilungenVerteilersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.MitteilungenVerteilers, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/mitteilungenverteilers/excel")]
        [HttpGet("/export/DbSinDarEla/mitteilungenverteilers/excel(fileName='{fileName}')")]
        public FileStreamResult ExportMitteilungenVerteilersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.MitteilungenVerteilers, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/modules/csv")]
        [HttpGet("/export/DbSinDarEla/modules/csv(fileName='{fileName}')")]
        public FileStreamResult ExportModulesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Modules, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/modules/excel")]
        [HttpGet("/export/DbSinDarEla/modules/excel(fileName='{fileName}')")]
        public FileStreamResult ExportModulesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Modules, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/notizens/csv")]
        [HttpGet("/export/DbSinDarEla/notizens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportNotizensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Notizens, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/notizens/excel")]
        [HttpGet("/export/DbSinDarEla/notizens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportNotizensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Notizens, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/protokolls/csv")]
        [HttpGet("/export/DbSinDarEla/protokolls/csv(fileName='{fileName}')")]
        public FileStreamResult ExportProtokollsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Protokolls, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/protokolls/excel")]
        [HttpGet("/export/DbSinDarEla/protokolls/excel(fileName='{fileName}')")]
        public FileStreamResult ExportProtokollsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Protokolls, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/regelnabwesenheitens/csv")]
        [HttpGet("/export/DbSinDarEla/regelnabwesenheitens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportRegelnAbwesenheitensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.RegelnAbwesenheitens, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/regelnabwesenheitens/excel")]
        [HttpGet("/export/DbSinDarEla/regelnabwesenheitens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportRegelnAbwesenheitensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.RegelnAbwesenheitens, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/vwbasealles/csv")]
        [HttpGet("/export/DbSinDarEla/vwbasealles/csv(fileName='{fileName}')")]
        public FileStreamResult ExportVwBaseAllesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.VwBaseAlles, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/vwbasealles/excel")]
        [HttpGet("/export/DbSinDarEla/vwbasealles/excel(fileName='{fileName}')")]
        public FileStreamResult ExportVwBaseAllesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.VwBaseAlles, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/vwbasekontaktes/csv")]
        [HttpGet("/export/DbSinDarEla/vwbasekontaktes/csv(fileName='{fileName}')")]
        public FileStreamResult ExportVwBaseKontaktesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.VwBaseKontaktes, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/vwbasekontaktes/excel")]
        [HttpGet("/export/DbSinDarEla/vwbasekontaktes/excel(fileName='{fileName}')")]
        public FileStreamResult ExportVwBaseKontaktesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.VwBaseKontaktes, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/vwbaseortes/csv")]
        [HttpGet("/export/DbSinDarEla/vwbaseortes/csv(fileName='{fileName}')")]
        public FileStreamResult ExportVwBaseOrtesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.VwBaseOrtes, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/vwbaseortes/excel")]
        [HttpGet("/export/DbSinDarEla/vwbaseortes/excel(fileName='{fileName}')")]
        public FileStreamResult ExportVwBaseOrtesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.VwBaseOrtes, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/vwbaseplzs/csv")]
        [HttpGet("/export/DbSinDarEla/vwbaseplzs/csv(fileName='{fileName}')")]
        public FileStreamResult ExportVwBasePlzsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.VwBasePlzs, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/vwbaseplzs/excel")]
        [HttpGet("/export/DbSinDarEla/vwbaseplzs/excel(fileName='{fileName}')")]
        public FileStreamResult ExportVwBasePlzsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.VwBasePlzs, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/vwbenutzerbases/csv")]
        [HttpGet("/export/DbSinDarEla/vwbenutzerbases/csv(fileName='{fileName}')")]
        public FileStreamResult ExportVwBenutzerBasesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.VwBenutzerBases, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/vwbenutzerbases/excel")]
        [HttpGet("/export/DbSinDarEla/vwbenutzerbases/excel(fileName='{fileName}')")]
        public FileStreamResult ExportVwBenutzerBasesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.VwBenutzerBases, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/vwkundenbetreuers/csv")]
        [HttpGet("/export/DbSinDarEla/vwkundenbetreuers/csv(fileName='{fileName}')")]
        public FileStreamResult ExportVwKundenBetreuersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.VwKundenBetreuers, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/vwkundenbetreuers/excel")]
        [HttpGet("/export/DbSinDarEla/vwkundenbetreuers/excel(fileName='{fileName}')")]
        public FileStreamResult ExportVwKundenBetreuersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.VwKundenBetreuers, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/vwkundenundbetreuerauswahls/csv")]
        [HttpGet("/export/DbSinDarEla/vwkundenundbetreuerauswahls/csv(fileName='{fileName}')")]
        public FileStreamResult ExportVwKundenUndBetreuerAuswahlsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.VwKundenUndBetreuerAuswahls, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/vwkundenundbetreuerauswahls/excel")]
        [HttpGet("/export/DbSinDarEla/vwkundenundbetreuerauswahls/excel(fileName='{fileName}')")]
        public FileStreamResult ExportVwKundenUndBetreuerAuswahlsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.VwKundenUndBetreuerAuswahls, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/vwmitarbeiters/csv")]
        [HttpGet("/export/DbSinDarEla/vwmitarbeiters/csv(fileName='{fileName}')")]
        public FileStreamResult ExportVwMitarbeitersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.VwMitarbeiters, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/vwmitarbeiters/excel")]
        [HttpGet("/export/DbSinDarEla/vwmitarbeiters/excel(fileName='{fileName}')")]
        public FileStreamResult ExportVwMitarbeitersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.VwMitarbeiters, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/vwmitarbeiterfirmens/csv")]
        [HttpGet("/export/DbSinDarEla/vwmitarbeiterfirmens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportVwMitarbeiterFirmensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.VwMitarbeiterFirmens, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/vwmitarbeiterfirmens/excel")]
        [HttpGet("/export/DbSinDarEla/vwmitarbeiterfirmens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportVwMitarbeiterFirmensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.VwMitarbeiterFirmens, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/vwmitarbeiterkundens/csv")]
        [HttpGet("/export/DbSinDarEla/vwmitarbeiterkundens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportVwMitarbeiterKundensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.VwMitarbeiterKundens, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/vwmitarbeiterkundens/excel")]
        [HttpGet("/export/DbSinDarEla/vwmitarbeiterkundens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportVwMitarbeiterKundensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.VwMitarbeiterKundens, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/vwmitarbeiterneus/csv")]
        [HttpGet("/export/DbSinDarEla/vwmitarbeiterneus/csv(fileName='{fileName}')")]
        public FileStreamResult ExportVwMitarbeiterNeusToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.VwMitarbeiterNeus, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/vwmitarbeiterneus/excel")]
        [HttpGet("/export/DbSinDarEla/vwmitarbeiterneus/excel(fileName='{fileName}')")]
        public FileStreamResult ExportVwMitarbeiterNeusToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.VwMitarbeiterNeus, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/vwmitarbeitersuchens/csv")]
        [HttpGet("/export/DbSinDarEla/vwmitarbeitersuchens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportVwMitarbeiterSuchensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.VwMitarbeiterSuchens, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/vwmitarbeitersuchens/excel")]
        [HttpGet("/export/DbSinDarEla/vwmitarbeitersuchens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportVwMitarbeiterSuchensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.VwMitarbeiterSuchens, Request.Query), fileName);
        }
        [HttpGet("/export/DbSinDarEla/vwmitarbeitertaetigkeitens/csv")]
        [HttpGet("/export/DbSinDarEla/vwmitarbeitertaetigkeitens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportVwMitarbeiterTaetigkeitensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.VwMitarbeiterTaetigkeitens, Request.Query), fileName);
        }

        [HttpGet("/export/DbSinDarEla/vwmitarbeitertaetigkeitens/excel")]
        [HttpGet("/export/DbSinDarEla/vwmitarbeitertaetigkeitens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportVwMitarbeiterTaetigkeitensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.VwMitarbeiterTaetigkeitens, Request.Query), fileName);
        }
    }
}
