import { Injectable } from '@angular/core';
import * as XLSX from 'xlsx';

@Injectable()
export class ExcelService {

  constructor() {
  }

  static toExportFileName(excelFileName: string): string {
    return `${excelFileName}_export_${new Date().getTime()}.xlsx`;
  }

  public exportAsExcelFile(json: any, excelFileName: string): void {
    console.log(json.toString());
    const worksheet: XLSX.WorkSheet = XLSX.utils.table_to_sheet(json,
      //   { 
      //   ignoreHiddenRows: true,
      //   ignoreHiddenCells: true
      // }
    );
    //Table2ToSheetOpts: false
    const workbook: XLSX.WorkBook = { Sheets: { 'data': worksheet }, SheetNames: ['data'] };
    XLSX.writeFile(workbook, ExcelService.toExportFileName(excelFileName), {});
    const excelBuffer: any = XLSX.write(workbook, { bookType: 'xlsx', type: 'array' });
  }
}