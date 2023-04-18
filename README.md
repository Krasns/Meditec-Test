# Meditec-Test
Izdarīts:
  - Ievadlauks, kuram pievienots AJAX, kurā tiek ģenerērts saraksts ar valstīm kurās ir ši burtu kombinācija. Atrodot Valsti pie tās tiek pievienots divas pogas - viena parāda brīvdienu sarakstu, otra (nepabeikta) aizsūta saraksti uz metodi, kura aizsūta uz DB. 
  - DB tika veidots ar code-first metodi.

Nepabeiktais:
  - Izskats: pievienotu laukiem bootstrap clases, lai būtu sakārtotāks
  - Validācijas nav pievienotas pie ievadlauka, pie API saņemšanas un Padodot datus uz DB. Un parādot valsts brīvdienu sarakstu vērtības netiek ierakstītas no jauna.
  - Saikne ar DB ar kuru tiks padoti dati uz DB un tiks ņemti dati no DB. Dati tiktu dalīti - ID (PK), Valsts nosaukums un pārējie dati.

