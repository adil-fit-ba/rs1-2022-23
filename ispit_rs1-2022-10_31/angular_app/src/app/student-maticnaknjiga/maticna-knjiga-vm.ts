
export interface ListaUpisi {
  id: number;
  akademska_godina_opis: string;
  godinastudina: number;
  jelObnova: boolean;
  datumUpisZimski: Date;
  datumOvjeraZimski?: any;
  cijenaSkolarine: number;
  evidentirao_korisnik: string;
}

export interface MaticnaKnjigaVM {
  student_id: number;
  ime: string;
  prezime: string;
  listaUpisi: ListaUpisi[];
  cijenaSkolarine: number;
}
