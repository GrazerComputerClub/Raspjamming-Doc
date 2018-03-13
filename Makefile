PROJECT=Raspjamming
PROJECT2=Raspjamming - Admin

TEX=pdflatex
BIBTEX=bibtex
BUILDTEX=$(TEX) "$(PROJECT).tex"
BUILDTEX2=$(TEX) "$(PROJECT2).tex"


all:
	- ${BUILDTEX} && ${BUILDTEX} && ${BUILDTEX}
	- ${BUILDTEX2} && ${BUILDTEX2} && ${BUILDTEX2}

clean-all:
	- /bin/rm -f *.dvi *.log *.bak *.aux *.bbl *.blg *.idx *.ps *.eps *.pdf *.toc *.out *~

clean:
	- /bin/rm -f *.log *.bak *.aux *.bbl *.blg *.idx *.toc *.out *~
