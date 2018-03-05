PROJECT=Raspjamming
TEX=pdflatex
BIBTEX=bibtex
BUILDTEX=$(TEX) "$(PROJECT).tex"


all:
	- ${BUILDTEX} && ${BUILDTEX} && ${BUILDTEX}

clean-all:
	- /bin/rm -f *.dvi *.log *.bak *.aux *.bbl *.blg *.idx *.ps *.eps *.pdf *.toc *.out *~

clean:
	- /bin/rm -f *.log *.bak *.aux *.bbl *.blg *.idx *.toc *.out *~
