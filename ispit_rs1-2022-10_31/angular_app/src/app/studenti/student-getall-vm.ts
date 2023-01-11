export interface StudentGetallVM {
  id: number;
  ime: string;
  prezime: string;
  opstina_rodjenja_id: number | null;
  opstina_rodjenja_opis: string;
  broj_indeksa: string;
  drzava_rodjenja_opis: string;
  vrijeme_dodavanja: string;
  slika_korisnika_nova_base64?: string | null;
  slika_korisnika_postojeca_base64_DB: string;
  slika_korisnika_postojeca_base64_FS: string;
  omiljenipredmeti:any;
}

export interface StudentGetallVMPagedList {
  dataItems: StudentGetallVM[];
  currentPage: number;
  totalPages: number;
  pageSize: number;
  totalCount: number;
  hasPrevios: boolean;
  hasNext: boolean;
}
